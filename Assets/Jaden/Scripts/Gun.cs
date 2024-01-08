using UnityEngine;

public class Gun : MonoBehaviour
{
    public bool canShoot = true;
    public float fireTime = 1;
    public GameObject Bullet;
    public Vector3 bulletOffset;

    private float bulletCooldown = 0;

    void Start()
    {
    }

    void FixedUpdate() // Shoot bullets every frame.
    {
        
        if (bulletCooldown > 0)
        {
            bulletCooldown -= Time.fixedDeltaTime;
            return;
        }
        if (Input.GetMouseButton(0))
        {
            bulletCooldown = fireTime;

            GameObject newBullet = Instantiate(Bullet, transform.position, transform.parent.rotation);
            BulletScript bulletScript = newBullet.GetComponent<BulletScript>();

            if (transform.parent.parent.localScale.x == -1)
            {
                bulletScript.bulletOffset = -bulletOffset;
                bulletScript.bulletDirection = transform.right;
            }
            else
            {
                bulletScript.bulletOffset = bulletOffset;
                bulletScript.bulletDirection = transform.right * -1;
            }

            bulletScript.enabled = true;
        }
    }

}
