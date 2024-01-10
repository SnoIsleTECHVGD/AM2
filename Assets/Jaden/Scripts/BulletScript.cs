using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class BulletScript : MonoBehaviour
{
    public int bulletSpeed = 1;
    public int bulletDamage = 5;
    public bool shouldHitPlayers = true;


    private BoxCollider2D myCollider;
    private SpriteRenderer mySprite;
    private Rigidbody2D myBody;

    public Vector2 bulletDirection;
    public Vector3 bulletOffset;

    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
        myCollider = GetComponent<BoxCollider2D>();
        myBody = GetComponent<Rigidbody2D>();

        mySprite.enabled = true;
        myCollider.enabled = true;

        Destroy(gameObject, 6.0f);
    }

    // Hit Detect
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 2) // Ignore Raycast
            return;

        Stats hitStats = collision.gameObject.GetComponent<Stats>();

        if (hitStats != null)
        {
            

            

            hitStats.TakeDamage(bulletDamage);
        }

        Destroy(gameObject);
    }

    

    Vector2 GetMouseDirection()
    {
        Vector3 dir = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        dir = Camera.main.ScreenToWorldPoint(dir);
        dir = dir - transform.position;

        return new Vector2(dir.x, dir.y);
    }

    IEnumerator WaitUntilTimeScale()
    {
        yield return new WaitUntil(() => Time.timeScale == 1);
        bulletDirection = GetMouseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
