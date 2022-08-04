using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemysuit : MonoBehaviour
{
    public int hp;
    public Transform playertran;
    public GameObject blud;
    public GameObject bullet;
    public GameObject muzzoffset;
    public GameObject cash;
    public Transform cashtran;

    public GameObject muzzfx;

    public float projectilevelo;

    public bool canshoot;


    
    public Animator anim;

    Rigidbody rb;
    public float atttimer;
    public float curratttimer;
    public float dedtimer;

    AudioSource aud;
    bool ded;
    pmove pmovref;
    // Start is called before the first frame update
    void Start()
    {
        curratttimer = atttimer;
        playertran = FindObjectOfType<playercol>().transform;
        pmovref = FindObjectOfType<pmove>();
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        curratttimer -= Time.deltaTime;
        muzzoffset.transform.LookAt(new Vector3(playertran.position.x, playertran.position.y, playertran.position.z + pmovref.fvel));
        if (!ded)
        {
            transform.LookAt(new Vector3(0, 0, playertran.position.z)); //wtf ????
        }

        if(ded)
        {
            dedtimer -= Time.deltaTime;
            //Instantiate(blud, gameObject.transform.position, gameObject.transform.rotation);
        }

        if (dedtimer <= 0)
        {
            Instantiate(cash, cashtran.position, cashtran.rotation);
            Destroy(this.gameObject);
        }

        if (curratttimer <= 0)
        {
            canshoot = true;
        }


        if (curratttimer <= 0 && canshoot && !ded)
        {
            shoot();
            curratttimer = atttimer;
            canshoot = false;

        }

        if(!canshoot)
        {
            //curratttimer = 0;
        }




    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12)
        {
            if (!ded)
            {
                anim.SetTrigger("Dead");
               // Instantiate(blud, collision.transform.position, collision.transform.rotation);
                ded = true;
            }
        }

     //duplicated in hammerscrp but this is the one working
        
    }
    
    public void damage(int num)
    {
        hp -= num;
        anim.SetTrigger("flash");

    }

    public void shoot()
    {
        GameObject currbullet = Instantiate(bullet, muzzoffset.transform.position, muzzoffset.transform.rotation);
        currbullet.GetComponent<Rigidbody>().AddForce(transform.forward * projectilevelo, ForceMode.Impulse);
        Instantiate(muzzfx, muzzoffset.transform.position, muzzoffset.transform.rotation);
        aud.Play();
        //anim.SetTrigger("Shoot");
        curratttimer = atttimer;
    }


}
