using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    GameObject p1;
    GameObject p2;
    public Transform fp1;
    public Transform fp2;
    public GameObject windSlash;
    Animator animator1;
    Animator animator2;
    public GameObject attackArea;
    float cdBetweenAttacksP1 = 2;
    float cdBetweenAttacksP2 = 2;
    float currentTimeP1;
    float currentTimeP2;
    public string animationName = "attack";

    private void Start()
    {
        p1 = GameObject.FindGameObjectWithTag("Player1");
        p2 = GameObject.FindGameObjectWithTag("Player2");
        animator1 = p1.GetComponent<Animator>();
        animator2 = p2.GetComponent<Animator>();
    }

    void Update()
    {
        currentTimeP1 += Time.deltaTime;
        currentTimeP2 += Time.deltaTime;

        //Debug.Log(currentTimeP2);
        if (currentTimeP1 > cdBetweenAttacksP1)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                currentTimeP1 = 0;
                animator1.Play(animationName);
                Instantiate(windSlash, fp1.position, fp1.rotation);
            }
        }

        AttackP2();
    }

    private void AttackP2()
    {
        if (currentTimeP2 <= cdBetweenAttacksP2) return;

        if (Input.GetKeyDown(KeyCode.M))
        {
            currentTimeP2 = 0;
            animator2.Play(animationName);
            Instantiate(windSlash, fp2.position, fp2.rotation);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        attackArea.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        attackArea.SetActive(false);
    }

}

