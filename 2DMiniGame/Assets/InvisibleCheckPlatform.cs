using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleCheckPlatform : MonoBehaviour
{
    public PLatformManager platManag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            collision.gameObject.SetActive(false);
            platManag.Begin(1);
        }
    }
}
