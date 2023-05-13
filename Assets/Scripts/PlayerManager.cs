using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TMP_Text lostText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text highscoreText;
    [SerializeField] GameObject highscore;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject backToMenuButton;

    float timeSpent = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSpent += Time.deltaTime;
        scoreText.text = Mathf.RoundToInt(timeSpent).ToString();
        if (timeSpent > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", timeSpent);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hostile"))
        {
            string lost = "You just lost!";
            lostText.text = lost + " Your stayed alive for: " + Mathf.Round(timeSpent);
            Time.timeScale = 0;
            Debug.Log("Game Paused");
            restartButton.SetActive(true);
            backToMenuButton.SetActive(true);
            highscore.SetActive(true);
            highscoreText.text = "Your highscore is: " + Mathf.Round(PlayerPrefs.GetFloat("HighScore"));
        }
    }
}
