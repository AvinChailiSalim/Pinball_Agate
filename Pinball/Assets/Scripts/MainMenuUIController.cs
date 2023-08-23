using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditButton;

    // Start is called before the first frame update
    void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditButton.onClick.AddListener(Credits);
    
    }

    private void PlayGame(){
        SceneManager.LoadScene("PinballGame");
    }

    private void ExitGame(){
        Application.Quit();
    }

    private void Credits(){
        SceneManager.LoadScene("Credits");
    }
}
