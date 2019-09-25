using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public PLatformManager platManag;
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platManag.countPlatform -= 1;
        if (collision.CompareTag("Platform"))
        {
            Debug.Log("ok8p");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        platManag.countPlatform++;
        platManag.Begin(1);
        Debug.Log("ok");
        Debug.Log(other.transform.tag);

        if (other.transform.tag == "Platform")
        {
            if(other.transform.position.x < player.transform.position.x)
            {
                Debug.Log("ok");
                other.gameObject.SetActive(false);
            }
            
        }
    }
}
