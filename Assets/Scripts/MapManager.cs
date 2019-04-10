using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;
using Assets.Scripts;

public class MapManager : MonoBehaviour
{
    public GameObject Grama, Cruce, Horizontal, Vertical, Arbol;
    
    public GameObject Player, Enemy1;
    public GameObject BoxClosed, BoxOpen, Gem;
    Dictionary<string, GameObject> characterPrefabs;
    Dictionary<string, GameObject> itemsPrefabs;
    Dictionary<char, GameObject> celdaPrefabs;
    Character _newChar;
    Item _newitem;
    
    GameObject newCel;
    XmlDocument level1;

    private void Awake()
    {
        characterPrefabs = new Dictionary<string, GameObject>
        {
            {"Pira-Guchi", Player },
            {"Enemy1", Enemy1 }
        };

        itemsPrefabs = new Dictionary<string, GameObject>
        {
            {"TreasureBlue", BoxClosed },
            //{"TreasureblueOpen", BoxOpen },
            {"GemYellow", Gem }
        };
        celdaPrefabs = new Dictionary<char, GameObject>
        {
            {'A', Arbol},
            {'E', Grama},
            {'I', Cruce},
            {'O', Vertical},
            {'U', Horizontal},
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        level1 = new XmlDocument();
        level1.LoadXml(Resources.Load<TextAsset>("map").text);
        Physics.IgnoreLayerCollision(0, 8);
        LoadMap();
        Player = GameObject.FindGameObjectWithTag("Player");
        Camera.main.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10);
        Camera.main.transform.SetParent(Player.transform);
    }

    private void LoadMap()
    {
        
        int j, i = 0;
        foreach(XmlNode filaActual in level1.SelectNodes("//Level/Map/Row"))
        {
            j = 0;
            i--;
            GameStateManager.CurrentGame.CurrentLevel.Map.Add(filaActual.InnerText);
            foreach(char celdaActual in filaActual.InnerText)
            {

                Instantiate(celdaPrefabs[celdaActual], new Vector3(j, i, celdaPrefabs[celdaActual].transform.position.z), Quaternion.identity);
                j++;
                
            }
        }

        foreach(XmlNode actualCharacter in level1.SelectNodes("//Level/Characters/Character"))
        {
            _newChar = new Character(int.Parse(actualCharacter.Attributes["Id"].Value), actualCharacter.Attributes["UniqueObjectName"].Value, 
                actualCharacter.Attributes["PrefabName"].Value, float.Parse(actualCharacter.Attributes["PosX"].Value),float.Parse( actualCharacter.Attributes["PosY"].Value));

            newCel = Instantiate(characterPrefabs[_newChar.PrefabName],
                new Vector3(_newChar.PosX, _newChar.PosY), Quaternion.identity);

            newCel.name = _newChar.UniqueObjectName;

            GameStateManager.CurrentGame.CurrentLevel.Characters.Add(_newChar);
        }

        foreach (XmlNode actualCharacter in level1.SelectNodes("//Level/Items/Item"))
        {
            _newitem = new Item(int.Parse(actualCharacter.Attributes["Id"].Value), actualCharacter.Attributes["UniqueObjectName"].Value,
                actualCharacter.Attributes["PrefabName"].Value, float.Parse(actualCharacter.Attributes["PosX"].Value), float.Parse(actualCharacter.Attributes["PosY"].Value));

            newCel = Instantiate(itemsPrefabs[_newitem.PrefabName],
                new Vector3(_newitem.PosX, _newitem.PosY), Quaternion.identity);

            newCel.name = _newitem.UniqueObjectName;

            GameStateManager.CurrentGame.CurrentLevel.Items.Add(_newitem);
        }
    }
}
