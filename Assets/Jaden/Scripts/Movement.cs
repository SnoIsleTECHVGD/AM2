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
    public GameObject WalkingParticle;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        grounded = true;
        animator = GetComponent<Animator>();
        WalkingParticle = GameObject.Find("WalkingParticles");
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
            WalkingParticle.GetComponent<ParticleSystem>().Play();
        } 
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetInteger("WalkDir", 0);
            WalkingParticle.GetComponent<ParticleSystem>().Stop();
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


        //Particle Stuff :))))))))))))
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            WalkingParticle.GetComponent<ParticleSystem>().Play();
            WalkingParticle.transform.position = WalkingParticle.transform.position * -1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            WalkingParticle.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            WalkingParticle.GetComponent<ParticleSystem>().Stop();
        }
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
