using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCheckPlatform : MonoBehaviour
{

    public PLatformManager platManag;
    //public PlayerController player;
    //public GameObject zonePlayer;
    //private Vector3 zoneOffset;

    // Start is called before the first frame update
    void Start()
    {
        //zoneOffset = transform.position - zonePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = zonePlayer.transform.position + zoneOffset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            collision.gameObject.SetActive(false);
            platManag.Begin(1);
        }
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    platManag.countPlatform++;
        

    //    if (collision.transform.tag == "Platform")
    //    {
    //        collision.gameObject.SetActive(false);
    //    }
    //}
}
