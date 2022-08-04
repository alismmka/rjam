using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class runshooter : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzoffset;

    public GameObject muzzfx;

    public TMP_Text ammotxt;

    float shoottimer;
    public float orishoottimer;
    public float projectilevelo;

    public int maxcap;
    int currcap;

    Animator gunanim;
    AudioSource aud;

    public AudioClip shootsfx;
    public AudioClip reloadsfx;

    public OVRInput.Controller currcontroller;


    // Start is called before the first frame update
    void Start()
    {
        currcap = maxcap;
        ammotxt.text = currcap.ToString();
        gunanim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        OVRGrabbable grabbable = this.gameObject.GetComponent<OVRGrabbable>();
        if (grabbable.grabbedBy != null)
        {
            currcontroller = grabbable.grabbedBy.m_controller;
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, currcontroller) && shoottimer <= 0 && currcap > 0)
        {
            shoot();
        }

        shoottimer -= Time.deltaTime;

       /* if(Vector3.Angle(transform.up, Vector3.up)>100 && currcap < maxcap)
        {
            reload();
        }*/

        

        
    }

    void shoot()
    {
        GameObject currbullet = Instantiate(bullet, muzzoffset.transform.position, muzzoffset.transform.rotation);
        currbullet.GetComponent<Rigidbody>().AddForce(transform.right * projectilevelo, ForceMode.Impulse);
        //aud.Stop();
        gunanim.SetTrigger("Shoot");
        currcap--;
        shoottimer = orishoottimer;
        ammotxt.text = currcap.ToString();
        aud.PlayOneShot(shootsfx);
        Instantiate(muzzfx, new Vector3(muzzoffset.transform.localPosition.x+0.5f, muzzoffset.transform.position.y, muzzoffset.transform.position.z), muzzoffset.transform.rotation);
        //OVRInput.SetControllerVibration(0.01f,0.03f, currcontroller);


    }

    void reload()
    {
        //aud.Stop();
        aud.PlayOneShot(reloadsfx);
        gunanim.SetTrigger("reload");
        currcap = maxcap;
        ammotxt.text = currcap.ToString();

    }
}
