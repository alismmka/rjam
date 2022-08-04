using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pmove : MonoBehaviour
{
    public bool jump;
    public bool land;

    public int fvel;
    public float JumpForce;
    public Vector3 oripos;
    Quaternion orirot;
    public playercol pcolref;

    //public GameObject[] backobjs;

    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        oripos = transform.position;
        orirot = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = orirot;
        /*
        if(transform.position.z>135)
        {
            foreach (GameObject item in backobjs)
            {
                Destroy(item);
            }
        }*/
        if (jump)
            {
            oripos = transform.position;

            transform.position += new Vector3(0, transform.lossyScale.y * JumpForce, 0);
            }

        if(land)
        {
            transform.position += new Vector3(0, transform.lossyScale.y * -JumpForce / 2, 0);
        }

        /*if(!jump && !land)
        {
            transform.position += Time.fixedDeltaTime * new Vector3(0, 0, fvel);
        }*/
        /*if (transform.position.y != oripos.y && !jump) //used to be else if
        {
            if (transform.position.y > oripos.y)
            {
                transform.position += new Vector3(0, transform.lossyScale.y * -JumpForce/2, 0);
            }
            if (transform.position.y < oripos.y)
            {
                transform.position += new Vector3(0, transform.lossyScale.y * JumpForce/2, 0);
            }
        }*/

        if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            //jump = true;
        }

if(OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            jump = false;
        }
    }

    void FixedUpdate()
    {
        if(!pcolref.playerded)
        transform.position += Time.fixedDeltaTime * new Vector3(0, 0, fvel);
        //if (grounded)
            //transform.position = new Vector3(transform.position.x, oripos.y, transform.position.z);
    }

    public void stopjump()
    {
        jump = false;
        land = true;
    }
}
