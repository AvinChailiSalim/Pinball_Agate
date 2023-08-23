using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampControl : MonoBehaviour
{
    public float score;

    public Collider bola;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other){
        if(other == bola){
            scoreManager.AddScore(score);
        }
    }
}
