using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLoader : MonoBehaviour
{
    [SerializeField] TMP_Text versionText;
    [SerializeField] TMP_Text highscoreText;
    string version = "Version 1.1 Stable";

    // Start is called before the first frame update
    void Start()
    {
        string os = SystemInfo.operatingSystem;
        versionText.text = version + " being played on: " + os;
        highscoreText.text = "Current highscore: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadAndStartGame()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

    public void LoadBackScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
