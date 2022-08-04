using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawnman : MonoBehaviour
{
    public Transform[] carspawns;
    public GameObject car;
    float timer;
    public float oritimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            Instantiate(car, carspawns[Random.Range(0, carspawns.Length)].transform.position, carspawns[Random.Range(0, carspawns.Length)].transform.rotation);
            timer = oritimer;
        }
    }
}
