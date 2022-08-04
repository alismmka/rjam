using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercol : MonoBehaviour
{
    public bool playerded;
    public float dedtimer;
    public GameObject gameoverpanel;
    public GameObject gameoverlight;
   // public GameObject scoremanref;
    public GameObject rhand;
    public GameObject lhand;
    public GameObject aud;

    public float slomodist;
    // Start is called before the first frame update
    void Start()
    {
        //dedtimer = 10f;
        //playerded = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.y < -50 || OVRInput.GetDown(OVRInput.Button.Start, OVRInput.Controller.LTouch))
        {
            SceneManager.LoadScene(0);
        }

        if (playerded)
        {
            GetComponent<BoxCollider>().isTrigger = false;
            dedtimer -= Time.deltaTime;
            aud.SetActive(true);
            gameoverpanel.SetActive(true);
            gameoverlight.SetActive(true);
            rhand.SetActive(false);
            lhand.SetActive(false);
           
                //scoremanref.SetActive(false);

        }

        if (dedtimer <= 0)
        {
            playerded = false;
            //GetComponent<BoxCollider>().isTrigger = true;
            SceneManager.LoadScene(0);

        }
    }

    public void playerdie()
    {
        playerded = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 || other.gameObject.layer ==11)
        {
            if (other.GetComponent<enemysuit>())
            {
                return;
            }
            else
            {
                playerded = true;
            }
        }
    }


}
