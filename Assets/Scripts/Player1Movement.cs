using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public GameObject player;
    float speed = 1;
    private int lifes = 6;

    void Update()
    {
        PlayerMovement();
        if (lifes <= 0)
        {
            Destroy(player);
        }
    }

    public void TakeDamage(int dmg)
    {
        lifes -= dmg;
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position += Vector3.left * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position += Vector3.forward * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position += Vector3.back * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position += Vector3.right * speed * Time.deltaTime;
            player.transform.rotation = Quaternion.LookRotation(Vector3.right);
        }

    }
}
