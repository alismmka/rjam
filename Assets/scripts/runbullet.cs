using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runbullet : MonoBehaviour
{
    public GameObject spark;
    public float destroytimer;

    public bool deflected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destroytimer -= Time.deltaTime;
        if (destroytimer <= 0)
        {
        Destroy(gameObject);
        }
    }

   void OnCollisionEnter(Collision collision)
    {
        Instantiate(spark, transform.position, transform.rotation);
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);

        }
        Destroy(gameObject);


    }




}
