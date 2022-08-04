using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hammerscrp : MonoBehaviour
{
    AudioSource aud;
    public GameObject boom;
    public GameObject spark;
    public Color stripcolor;
    public MeshRenderer rndr;
    public GameObject bullet;

    public AudioClip slicesfx;
    public AudioClip pingfx;

    public GameObject ricofx;

    public GameObject fragments;
    public GameObject fragtran;

    public TrailRenderer trndr;

    public OVRInput.Controller currcontroller;

    Rigidbody rb;
  //  public simplescore scoreref;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
       // scoreref = FindObjectOfType<simplescore>();
    }

    // Update is called once per frame
    void Update()
    {

        OVRGrabbable grabbable = this.gameObject.GetComponent<OVRGrabbable>();
        if (grabbable.grabbedBy != null)
        {
            currcontroller = grabbable.grabbedBy.m_controller;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer ==9 && FindObjectOfType<enemysuit>())
        {
            if (collision.gameObject.GetComponent<runbullet>().deflected == false)
            {
                OVRInput.SetControllerVibration(0.01f, 0.02f, currcontroller);

                GameObject refbullet = Instantiate(bullet, collision.transform.position, collision.transform.rotation);
               // Instantiate(ricofx, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);
                refbullet.transform.LookAt(FindObjectOfType<enemysuit>().transform);
                refbullet.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
                aud.PlayOneShot(pingfx);
                collision.gameObject.GetComponent<runbullet>().deflected = true;
            }
            else
            {
                return;
            }

        }

        if (collision.gameObject.CompareTag("enemy")) //duplicated in caraudio and enemysuit
        {
            aud.PlayOneShot(slicesfx);
            OVRInput.SetControllerVibration(0.01f, 0.06f, currcontroller);
            Instantiate(boom, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Instantiate(fragments, fragtran.transform.position, fragtran.transform.rotation);
            Destroy(gameObject);

            //scoreref.scorenum++;
            //collision.gameObject.GetComponent<caraudio>().ded = true;
            //collision.gameObject.GetComponent<ConstantForce>().enabled = false;
            //collision.gameObject.GetComponent<Rigidbody>().velocity = transform.up;

        }

        if (rb.velocity.x>0.1|| rb.velocity.y > 0.1 || rb.velocity.z > 0.1)
        {
            Instantiate(spark, collision.transform.position, collision.transform.rotation);
            rndr.material.SetColor("_EmissionColor", stripcolor);
            trndr.emitting = true;
        }

        else
        {
            rndr.material.SetColor("_EmissionColor", Color.black);
            trndr.emitting = false;

        }


    }

    public void frag()
    {
        Instantiate(fragments, fragtran.transform.position, fragtran.transform.rotation);
        Destroy(gameObject);
    }
}
