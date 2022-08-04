using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class droneman : MonoBehaviour
{
    public float orispawntimer;
    public float currspawntimer;

    public GameObject rdrone;
    public GameObject ldrone;

    drone rdroneref;
    drone ldroneref;

    Transform playertran;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        playertran = FindObjectOfType<playercol>().transform;
        currspawntimer = orispawntimer;
        anim = GetComponent<Animator>();
        rdroneref = rdrone.GetComponent<drone>();
        ldroneref = ldrone.GetComponent<drone>();
    }

    // Update is called once per frame
    void Update()
    {
      
            transform.position = new Vector3(transform.position.x, transform.position.y, playertran.position.z);
        
        currspawntimer -= Time.deltaTime;
        if (currspawntimer <= 0)
        {
            droneon();
            currspawntimer = orispawntimer;
        }
    }

    void droneon()
    {
        int r = Random.Range(0, 4);

        switch(r)
        {
            case 0:
                rdrone.SetActive(false);
                ldrone.SetActive(false);
                break;

            case 1:
                rdrone.SetActive(true);
                rdroneref.curratttimer = rdroneref.atttimer;
                rdroneref.canshoot = true;
                anim.Play(0,0);
                ldrone.SetActive(false);
                break;
            case 2:
                rdrone.SetActive(false);
                ldrone.SetActive(true);
                ldroneref.curratttimer = ldroneref.atttimer;
                ldroneref.canshoot = true;
                anim.Play(0, 0);
                break;
            case 3:
                rdrone.SetActive(true);
                rdroneref.curratttimer = rdroneref.atttimer;
                rdroneref.canshoot = true;
                anim.Play(0, 0);
                ldrone.SetActive(true);
                ldroneref.curratttimer = ldroneref.atttimer;
                ldroneref.canshoot = true;
                break;
            default:
                break;


        }

    }
}
