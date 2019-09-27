using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    public float forceJump = 5f;
    public Rigidbody2D _rigidbody2D;
    public bool canJump;
    public bool inTheGround;
    public GameObject player;

    private bool gameIsOver = false;

    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        inTheGround = true;
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            inTheGround = true;
        }
    }
<<<<<<< Updated upstream
=======
    
>>>>>>> Stashed changes
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            inTheGround = false;
        }
<<<<<<< Updated upstream
=======
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
>>>>>>> Stashed changes
    }
}
