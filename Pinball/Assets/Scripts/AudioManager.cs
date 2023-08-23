using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    public GameObject sfxAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBGM(){
        bgmAudioSource.Play();
    }

    public void PlaySFX(Vector3 spawnPos){
        GameObject.Instantiate(sfxAudioSource, spawnPos, Quaternion.identity);

        
    }
}
