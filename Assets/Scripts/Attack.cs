using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject attackArea;
    public GameObject onArea;
    public GameObject offArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == onArea)
        {
            attackArea.SetActive(true);
        }
        if(other == offArea)
        {
            attackArea.SetActive(false);
        }
    }

}
