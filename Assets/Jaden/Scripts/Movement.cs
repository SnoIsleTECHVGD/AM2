using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb2d;
    public float jumpSpeed;
    public int maxSpeed;
    public int fallSpeed;
    public float maxJump;
    private bool grounded;
    public float cooldown;
    [SerializeField] private bool dashing;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        grounded = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if(grounded)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                grounded = false;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
            animator.SetInteger("LastDir", 1);
            animator.SetInteger("WalkDir", 2);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            animator.SetInteger("LastDir", 0);
            animator.SetInteger("WalkDir", 1);
        } else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetInteger("WalkDir", 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -fallSpeed);
        }
        if(rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if(rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.y > maxJump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, maxJump);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        }
        cooldown -= .01f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
        }
    }
    private IEnumerator Dash()
    {
        if (cooldown <= 0)
        {
            dashing = true;
            speed = speed * 2;
            maxSpeed = maxSpeed * 2;
            jumpSpeed = jumpSpeed * 1.3f;
            maxJump = maxJump * 1.3f;
            cooldown = 15;
            yield return new WaitForSeconds(.25f);
            speed = speed / 2;
            maxSpeed = maxSpeed / 2;
            jumpSpeed = jumpSpeed / 1.3f;
            maxJump = maxJump / 1.3f;
            dashing = false;
        }
        
    }
}
