﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitsSpawn : MonoBehaviour
{
    public PLatformManager platManag;
    public PlayerController player;
    public GameObject left;
    public GameObject right;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platManag.countPlatform -= 1;
        //if (collision.CompareTag("Platform"))
        if (collision.transform.position.x <= right.transform.position.x)
        {
            collision.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        platManag.countPlatform++;
        platManag.Begin(1);

        if (other.CompareTag("Platform"))
        {
            if (other.transform.position.x <= left.transform.position.x)
            {
                other.gameObject.SetActive(false);
            }

        }
        if (other.CompareTag("gold"))
        {
            Debug.Log("fr");
            if (other.transform.position.x <= left.transform.position.x)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}