using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyactivator : MonoBehaviour
{

    public GameObject eobj;
    public GameObject eobj2;

    public autodestruct desref;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            desref.enabled = true;
            if (Random.Range(0, 2) == 0)
            {
                eobj.SetActive(true);
            }
            if (Random.Range(0, 2) == 0)
            {
                eobj2.SetActive(true);
            }
        }
    }
}
