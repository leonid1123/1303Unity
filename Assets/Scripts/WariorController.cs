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
    private float jumpForce = 9f;
    private bool canJump = false;
    public int coins = 0;
    public int HP = 0;
    public TMP_Text coinsText;
    public TMP_Text hpText;
    public Animator animator;
    private void Start()
    {
        HP = 3;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
        dir = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("walk",Mathf.Abs(dir));

        

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
        hpText.text = "HP:" + HP.ToString();

        if(HP<=0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground" || collision.tag=="platform")
        {
            canJump = true;
            Debug.Log("на земле");
        }
        if (collision.tag == "coin")
        {
            coins++;
            coinsText.text = "Coins:" + coins.ToString();
        }
        if(collision.tag =="pikes")
        {
            HP=0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ground" || collision.tag=="platform")
        {
            canJump = false;
            Debug.Log("не на земле");
        }
    }
}
