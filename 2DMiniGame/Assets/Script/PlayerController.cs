using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D _rigidbody2D;
    public float speed = 0.1f;
    public float forceJump = 5f;

    public bool canJump;
    public bool inTheGround;

    public GameObject player;
    public Text countText;
    public int count;

    //private bool gameIsOver = false;

    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        inTheGround = true;
        count = 0;
        CountGoldToText();
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            canJump = false;
            _rigidbody2D.velocity = Vector2.up * forceJump;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("z") && inTheGround)
        {
            canJump = true;
            inTheGround = false;
        }

        if (Input.GetKey("q"))
        {
            transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(speed, 0, 0);
        }
        
        if (transform.position.y <= -25)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            inTheGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == 10)
        {
            StartCoroutine(UpperJump(1f));
            
        }
    }

    private IEnumerator UpperJump(float waitTime)
    {
        forceJump += 2f;
        yield return new WaitForSeconds(waitTime);
        forceJump = 5f;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            inTheGround = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("gold"))
        {
            count++;
            collision.gameObject.SetActive(false);
            //PENSER à réactiver et à placer 2 marqueurs sur l'écran pour prendre juste les X et faire apparaitre et disparaitre en fonction de ca plutot que le bxcol
            //tricher avec XgoldSprite > Xobjet
            CountGoldToText();
        }
    }

    private void CountGoldToText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
