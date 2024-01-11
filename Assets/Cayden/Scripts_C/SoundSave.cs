using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSave : MonoBehaviour
{
    AudioSource AudioSource1;
    // Start is called before the first frame update
    void Start()
    {
        float MasterVolume = PlayerPrefs.GetFloat("SavedMasterVolume");
        AudioSource1 = GetComponent<AudioSource>();
        AudioSource1.volume = MasterVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
