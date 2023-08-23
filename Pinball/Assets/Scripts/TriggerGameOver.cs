using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerGameOver : MonoBehaviour
{

    public Collider bola;
    public GameObject gameOverCanvas;
    public Button mainMenuButton;

    void Start(){
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    private void OnTriggerEnter(Collider other){
        if(other == bola){
            Debug.Log("Collided");
            gameOverCanvas.SetActive(true);
        }
    }

    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
