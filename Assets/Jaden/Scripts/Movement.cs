using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 6.5f;
    Rigidbody2D rb2d;
    public float jumpSpeed = 75;
    public int maxSpeed = 10;
    public int fallSpeed = 10;
    public float maxJump = 10;
    private bool grounded = true;
    public float cooldown = 0;
    public bool dashing = false;
    private float lastCooldown;
    public float intervalBetweenDashing;
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
                animator.SetBool("IsJump",true);
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
        } 
        else
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
        if(Input.GetKeyDown(KeyCode.LeftShift) && grounded)
        {
            StartCoroutine(Dash());
            
        }
        cooldown = Time.realtimeSinceStartup  - lastCooldown - intervalBetweenDashing;


        /*Particle Stuff :))))))))))))
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (grounded) 
            { 
                WalkingParticle.GetComponent<ParticleSystem>().Play();
                WalkingParticle.transform.localPosition = new Vector3(-0.536f, -1.751f, 0f);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (grounded)
            {
                WalkingParticle.GetComponent<ParticleSystem>().Play();
                WalkingParticle.transform.localPosition = new Vector3(0.536f, -1.751f, 0f);
            }
        }
        else
        {
            if (!grounded)
            {
                WalkingParticle.GetComponent<ParticleSystem>().Stop();
            } else if (rb2d.velocity != g)
            {
                if(WalkingParticle.GetComponent<ParticleSystem>().isStopped)
                WalkingParticle.GetComponent<ParticleSystem>().Play();
            }
        } */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            grounded = true;
            animator.SetBool("IsJump", false);
        }
    }
    private IEnumerator Dash()
    {
        if (cooldown >= 0)
        {
            lastCooldown = Time.realtimeSinceStartup;
            animator.SetBool("IsDoge", true);
            dashing = true;
            speed = speed * 2;
            maxSpeed = maxSpeed * 2;
            jumpSpeed = jumpSpeed * 1.3f;
            maxJump = maxJump * 1.3f;
            cooldown = 1f;
            yield return new WaitForSeconds(.5f);
            speed = speed / 2;
            maxSpeed = maxSpeed / 2;
            jumpSpeed = jumpSpeed / 1.3f;
            maxJump = maxJump / 1.3f;
            dashing = false;
            animator.SetBool("IsDoge", false);

        }
        
    }
}
