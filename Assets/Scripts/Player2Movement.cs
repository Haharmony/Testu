using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public GameObject player;
    float speed = 2;
    float lifes = 3;
    public TextMeshProUGUI p2Lifes;

    void Update()
    {
        PlayerMovement();
        p2Lifes.text = lifes.ToString();

        if (lifes > 0) return;
        this.gameObject.SetActive(false);       
    }

    public void TakeDamage(float dmg)
    {
        lifes -= dmg;
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.J))
        {
            player.transform.position += Vector3.left * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        if (Input.GetKey(KeyCode.I))
        {
            player.transform.position += Vector3.forward * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.K))
        {
            player.transform.position += Vector3.back * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
        if (Input.GetKey(KeyCode.L))
        {
            player.transform.position += Vector3.right * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
    }
}
