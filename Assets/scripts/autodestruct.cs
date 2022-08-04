using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodestruct : MonoBehaviour
{
    public float oridstimer;
    float currdstimer;
    // Start is called before the first frame update
    void Start()
    {
        currdstimer = oridstimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(currdstimer<=0)
        {
            Destroy(gameObject);
        }
        if(gameObject.activeSelf)
        {
            currdstimer -= Time.deltaTime;
        }
    }
}
