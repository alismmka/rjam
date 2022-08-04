using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public GameObject bomb;
    public GameObject heart;
    public GameObject boom;

   
    public float destimer;
    bool saved;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        destimer -= Time.deltaTime;
        

        if(destimer<=0)
        {
            if(saved)
            {
                Instantiate(heart, bomb.transform.position, bomb.transform.rotation);
                Destroy(gameObject);
            }
            Instantiate(boom, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 12)
        {
            Instantiate(heart,bomb.transform.position,bomb.transform.rotation);
            Destroy(bomb);
            GetComponent<Rigidbody>().isKinematic = true;  //so it wouldnt fly off
            saved = true;
            
        }
    }
}
