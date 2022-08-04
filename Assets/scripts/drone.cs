using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    public bool right;

    public int shootangle;

    public Transform playertran;
    public Transform bakplayertran;

    public GameObject bullet;
    public GameObject muzzoffset;
    public GameObject barrel;


    public GameObject boom;

    public float projectilevelo;

    public bool canshoot;
    public float atttimer;
    public float curratttimer;

    AudioSource aud;
    pmove pmovref;
    // Start is called before the first frame update
    void Start()
    {
        curratttimer = atttimer;
        aud = GetComponent<AudioSource>();
        playertran = FindObjectOfType<playercol>().transform;
        bakplayertran = FindObjectOfType<backcol>().transform;
        pmovref = FindObjectOfType<pmove>();

    }

    // Update is called once per frame
    void Update()
    {
        barrel.transform.LookAt(new Vector3(0, playertran.position.y, playertran.position.z));
        //muzzoffset.transform.LookAt(new Vector3(playertran.position.x, playertran.position.y, playertran.position.z + pmovref.fvel));
        muzzoffset.transform.LookAt(new Vector3(bakplayertran.position.x, bakplayertran.position.y, bakplayertran.position.z - pmovref.fvel));

        curratttimer -= Time.deltaTime;

        if(shootangle > 8)
        {
            shootangle = 0;
        }

        if (curratttimer <= 0)
        {
            canshoot = true;
        }
        
       
        
            if (curratttimer <= 0 && canshoot)
        {
            shoot();
            curratttimer = atttimer;
            canshoot = false;

        }

        if (!canshoot)
        {
           // curratttimer = 0;
        }
    }

    public void shoot()
    {
        GameObject currbullet = Instantiate(bullet, muzzoffset.transform.position, muzzoffset.transform.rotation);



        currbullet.transform.LookAt(playertran);
        currbullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        currbullet.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        currbullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectilevelo, ForceMode.Impulse);
        if (right)
        {
            currbullet.GetComponent<Rigidbody>().AddForce(transform.right * -projectilevelo * shootangle, ForceMode.Impulse);
        }
        else
        {
            currbullet.GetComponent<Rigidbody>().AddForce(transform.right * projectilevelo * shootangle, ForceMode.Impulse);
        }
        aud.Play();
        //anim.SetTrigger("Shoot");
        shootangle++;
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12)
        {
            Instantiate(boom, collision.transform.position, collision.transform.rotation);
            curratttimer = atttimer;
            gameObject.SetActive(false);
        }
    }
}
