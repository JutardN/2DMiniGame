using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Malus : MonoBehaviour
{
    private float timeLess = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Disengaged(2));
    }

    private IEnumerator Disengaged(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }

}
