using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject player1;
    GameObject player2;

    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("P1");
        player2 = GameObject.FindGameObjectWithTag("P2");
    }

    void Update()
    {
        if (player1 == null)
        {
            Debug.Log("Player 2 Wins!");
        }

        if (player2 == null)
        {
            Debug.Log("Player 1 Wins!");
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
