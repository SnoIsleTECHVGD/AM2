using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class EnemyBulletScript : MonoBehaviour
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

        transform.Translate(bulletOffset, Space.Self);
        Destroy(gameObject, 6.0f);
    }

    // Hit Detect
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 2) // Ignore Raycast
            return;
        Stats hitStats = collision.gameObject.GetComponent<Stats>();

        if (hitStats)
        {
            hitStats.TakeDamage(bulletDamage);
        }
        if (collision.name == "Player")
        {
            if (!collision.GetComponent<Movement>().dashing)
            {
                Destroy(gameObject);
            }
        }
        else
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        myBody.velocity = bulletDirection * bulletSpeed;
    }
}
    