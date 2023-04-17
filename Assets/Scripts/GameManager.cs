using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;
    public GameObject p1WinPanel;
    public GameObject p2WinPanel;
    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;
    int p1Score;
    int p2Score;

    void Start()
    {
        //Me subcriubo a el playerMovement para saber cuando muere
        player1 = GameObject.FindGameObjectWithTag("P1");
        player2 = GameObject.FindGameObjectWithTag("P2");
        Time.timeScale = 1;
    }

    void Update()
    {
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();

        if (!player1.activeSelf)
        {
            Debug.Log("Player 2 Wins!");
            p2WinPanel.SetActive(true);
            Time.timeScale = 0;
        }

        if (!player2.activeSelf)
        {
            Debug.Log("Player 1 Wins!");
            p1WinPanel.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void RestartGame()
    {
        if(!player1.activeSelf)
        {
            SceneManager.LoadScene("SampleScene");
            p2Score++;
        }
        if (!player2.activeSelf)
        {
            SceneManager.LoadScene("SampleScene");
            p1Score++;
        }

        SceneManager.LoadScene("SampleScene");
    }


}
