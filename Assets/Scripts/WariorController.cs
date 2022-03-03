using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WariorController : MonoBehaviour
{
    public Rigidbody2D rb2d;
    private float dir = 0f;
    private float speed = 5f;
    private bool toRight = true;
    public float jumpForce = 9f;
    private bool canJump = false;
    public int coins = 0;
    public TMP_Text coinsText;
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            
            SceneManager.LoadScene("SampleScene");
        }
        dir = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(dir * speed, rb2d.velocity.y);
        if (toRight && rb2d.velocity.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
            toRight = false;
        }
        else if (!toRight && rb2d.velocity.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
            toRight = true;
        }

        if (Input.GetButton("Jump") && canJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            canJump = true;
            Debug.Log("на земле");
        }
        if (collision.tag == "coin")
        {
            coins++;
            coinsText.text = "Coins:" + coins.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground")
        {
            canJump = false;
            Debug.Log("не на земле");
        }
    }
}
