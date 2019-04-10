using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource HoverSound,ClickSound,ExitSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHoverSound()
    {
        HoverSound.Play();
    }

    public void PlayClickedSound()
    {
        ClickSound.Play();
    }

    public void PlayExitSound()
    {
        ExitSound.Play();
    }
}
