using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] TMP_Text lostText;
    [SerializeField] TMP_Text scoreText;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hostile"))
        {
            string lost = "You just lost!";
            lostText.text = lost + " Your stayed alive for: " + Mathf.Round(timeSpent);
            Time.timeScale = 0;
            Debug.Log("Game Paused");
        }
    }
}
