using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caraudio : MonoBehaviour
{
    public AudioSource honkaud;
    public AudioClip honkclip;
    public GameObject boom;
    public float dedtimer;
    float currdedtimer;
    public bool ded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        currdedtimer = dedtimer;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }

     // rb.AddForce(new Vector3(0, 0, -5), ForceMode.Force);
    
    // currdedtimer -= Time.fixedDeltaTime;


    /*if (currdedtimer <= 0)
    {
        Destroy(gameObject);

    }*/
}

    private void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * new Vector3(0, 0, -15);

    }

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if(collision.gameObject.CompareTag("Player"))
        {
            honkaud.Play();
            GetComponent<AudioSource>().clip = honkclip;
        }

        if (collision.gameObject.layer == 12) //duplicated in hammerscrp
        {
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }*/
    }
}
