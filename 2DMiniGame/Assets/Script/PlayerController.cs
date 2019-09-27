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
    public PLatformManager platManag;
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
        
        if (transform.position.y <= platManag.position.y - 10)
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
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            inTheGround = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("gold"))
        {
            count++;
            collision.gameObject.SetActive(false);
            CountGoldToText();
        }
    }

    private void CountGoldToText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
