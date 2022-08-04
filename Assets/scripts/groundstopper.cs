using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundstopper : MonoBehaviour
{
    pmove pmoveref;
    Vector3 oriposr;
    bool tranlogged;
    // Start is called before the first frame update
    void Start()
    {
        pmoveref = FindObjectOfType<pmove>();
        

    }

    // Update is called once per frame
    void Update()
    {
       /* if(!tranlogged)
        {
            oriposr = pmoveref.oripos;
            tranlogged = true;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          /*  pmoveref.oripos = oriposr;
            pmoveref.gameObject.transform.position = oriposr;
            pmoveref.grounded = true; */
          //  pmoveref.land = false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        //pmoveref.grounded = false;

    }
}
