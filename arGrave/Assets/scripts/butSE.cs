using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botSE : MonoBehaviour
{
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
   
    
    public void OnClick()
    {
        sound.PlayOneShot(sound.clip);
    }
}
