using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using System.Runtime.Serialization;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Xml;

public class GameStateManager : MonoBehaviour
{
    string rutaXml;
    XmlDocument level1;
    public static Game CurrentGame;

    private void Awake()
    {
        level1 = new XmlDocument();
        level1.LoadXml(Resources.Load<TextAsset>("map").text);
        CurrentGame = new Game();
        rutaXml = Application.persistentDataPath + "/LastGameState.xml"; 
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Debug.Log(rutaXml);
            CurrentGame.PlayerName = "Ruben";
            SaveState();
        }
        else if (Input.GetKeyDown(KeyCode.F6))
        {
            LoadState();
        }
    }
    public void SaveState()
    {
        GameObject[] characters;
        GameObject[] items;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        characters = new GameObject[3];
        characters = GameObject.FindGameObjectsWithTag("Enemy");
        items = new GameObject[3];
        items = GameObject.FindGameObjectsWithTag("Item");
        int i = 0;
        foreach (XmlNode ActualPlayer in level1.SelectNodes("//Level/Characters/Character"))
        {
            if (ActualPlayer.Attributes["PrefabName"].Value == "Enemy1")
            {
                ActualPlayer.Attributes["PosX"].Value = characters[i].transform.position.x.ToString();
                ActualPlayer.Attributes["PosY"].Value = characters[i].transform.position.y.ToString();
                i++;
            }

            else if(ActualPlayer.Attributes["Id"].Value == "0")
            {
                ActualPlayer.Attributes["PosX"].Value = player.transform.position.x.ToString();
                ActualPlayer.Attributes["PosY"].Value = player.transform.position.y.ToString();
            }

            
        }
        /*i = 0;
        foreach (XmlNode actualItem in level1.SelectNodes("//Level/Items/Item"))
        {
            actualItem.Attributes["PosX"].Value = items[i].transform.position.x.ToString();
            actualItem.Attributes["PosY"].Value = items[i].transform.position.y.ToString();
            i++;
        }*/

        level1.Save("C:/Users/ruben/Desktop/Coding/Unity Games/New Unity Project/Assets/Resources/map.xml");
        
        DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));

        using (FileStream fstream = new FileStream(rutaXml, FileMode.Create))
        {
            dcSerializer.WriteObject(fstream, CurrentGame);
        }

        
    }

    public void LoadState()
    {
        /*   DataContractSerializer dcSerializer = new DataContractSerializer(typeof(Game));

           using (FileStream fstream = new FileStream(rutaXml, FileMode.Open))
           {
               CurrentGame = (Game)dcSerializer.ReadObject(fstream);
           }*/

        SceneManager.LoadScene("Level1");


    }
}
