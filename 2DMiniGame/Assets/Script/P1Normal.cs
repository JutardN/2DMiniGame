using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Normal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Disengaged(2f));
    }

    private IEnumerator Disengaged(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
