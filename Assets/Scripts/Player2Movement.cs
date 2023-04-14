using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public GameObject player;
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
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
