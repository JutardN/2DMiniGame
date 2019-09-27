using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Malus : MonoBehaviour
{
    private bool canMoveDown = false;
    void Update()
    {
        if (canMoveDown)
        {
            transform.Translate(0, -0.02f, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        canMoveDown = true;
        StartCoroutine(Disengaged(0.8f));
    }

    private IEnumerator Disengaged(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }

}
