using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Player1Movement : MonoBehaviour
{
    public GameObject player;
    float speed = 2;
    float lifes = 3;
    public TextMeshProUGUI p1Lifes;
    public string HoriztonalName;
    public string VerticalName;

    void Update()
    {
        PlayerMovement();
       
        p1Lifes.text = lifes.ToString();
        if (lifes > 0) return;
        this.gameObject.SetActive(false); 
        //me mori le mando esta info a quien lo necesiute
    }

    public void TakeDamage(float dmg)
    {
        lifes -= dmg;
    }

    void PlayerMovement()
    {
        player.transform.position += speed * Time.deltaTime * new Vector3(Input.GetAxis(HoriztonalName), 0, Input.GetAxis(VerticalName));
        player.transform.rotation = Quaternion.LookRotation(new Vector3(Input.GetAxis(HoriztonalName), 0, Input.GetAxis(VerticalName)));

        //if (Input.GetKey(KeyCode.A))
        //{
        //    player.transform.position += Vector3.left * speed * Time.deltaTime;
        //    player.transform.rotation = Quaternion.LookRotation(Vector3.left);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    player.transform.position += Vector3.forward * speed * Time.deltaTime;
        //    player.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    player.transform.position += Vector3.back * speed * Time.deltaTime;
        //    player.transform.rotation = Quaternion.LookRotation(Vector3.back);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    player.transform.position += Vector3.right * speed * Time.deltaTime;
        //    player.transform.rotation = Quaternion.LookRotation(Vector3.right);
        //}

    }
}
