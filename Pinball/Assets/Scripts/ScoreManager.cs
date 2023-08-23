using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public float score;

    // Start is called before the first frame update
    void Start()
    {
        ResetScore();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(float addition){
        score += addition;
    }

    public void ResetScore(){
        score = 0;
    }
}
