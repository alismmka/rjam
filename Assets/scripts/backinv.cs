using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backinv : MonoBehaviour
{
    public bool spawned;
    public bool r;
    public GameObject sword;

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
        //&&OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        if (other.gameObject.layer==17 || other.gameObject.layer == 18) 
        {
            GameObject nuswrd = Instantiate(sword, other.transform.position, other.transform.rotation, transform);
            other.gameObject.GetComponent<OVRGrabber>().m_grabbedObj = nuswrd.GetComponent<OVRGrabbable>();

            //Instantiate(sword, other.transform.position, other.transform.rotation, transform);

            //if (!spawned) //extra check needed if using stay
            //  spawned = true;

        }
    }


}
