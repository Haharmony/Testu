using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private float speed = 5f;
    int dmg = 1;
    public Rigidbody rb;

    void Update()
    {
        rb.velocity = transform.right*-1 * speed;
        Destroy(gameObject, 4f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "P1" || collision.tag == "LimitBorders")
        {
            Player1Movement p1 = collision.GetComponent<Player1Movement>();
            if (p1 != null)
            {
                p1.TakeDamage(dmg);
            }
            Destroy(gameObject);
        }
        if (collision.tag == "P2" || collision.tag == "LimitBorders")
        {
            Player2Movement p2 = collision.GetComponent<Player2Movement>();
            if (p2 != null)
            {
                p2.TakeDamage(dmg);
            }
            Destroy(gameObject);
        }
    }
}
