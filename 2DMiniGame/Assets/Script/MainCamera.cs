using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public PLatformManager platManag;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        platManag.countPlatform -= 1;
        if(collision.CompareTag("Platform"))
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
            Debug.Log("ok");
            other.gameObject.SetActive(false);
        }
    }
}
