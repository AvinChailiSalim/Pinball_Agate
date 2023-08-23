using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxManager : MonoBehaviour
{

    public GameObject vfxSource;
    
    public void PlayVFX(Vector3 spawnPos){
        GameObject.Instantiate(vfxSource, spawnPos, Quaternion.identity);
    }
}
