using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Queue&Stacks");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
