using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cashcase : MonoBehaviour
{
    Animator anim;
    public GameObject txt;
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(FindObjectOfType<playercol>().transform);

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12)
        {
            aud.Play();
            anim.SetBool("open", true);
            txt.SetActive(true);
        }
    }
}
