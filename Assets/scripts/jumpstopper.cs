using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpstopper : MonoBehaviour
{
    pmove pmoveref;
    // Start is called before the first frame update
    void Start()
    {
        pmoveref = FindObjectOfType<pmove>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pmoveref.jump = false;
            other.gameObject.SendMessageUpwards("stopjump");
        }
    }
}
