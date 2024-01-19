using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public bool canShoot = true;
    public float fireTime = 1;
    public GameObject Bullet;
    public Vector3 bulletOffset;

    public float minTimeToShoot = 0.1f;
    public float maxTimeToShoot = 0.5f;

    public bool isShooting = false;

    private float bulletCooldown = 0;

    void Start()
    {
    }

    void FixedUpdate() // Shoot bullets every frame.
    {
        if (isShooting != true)
            return;

        if (bulletCooldown > 0)
        {
            bulletCooldown -= Time.fixedDeltaTime;
            return;
        }
        bulletCooldown = fireTime + Random.Range(minTimeToShoot, maxTimeToShoot);

        GameObject newBullet = Instantiate(Bullet, transform.position, transform.parent.rotation);
        EnemyBulletScript bulletScript = newBullet.GetComponent<EnemyBulletScript>();

        if (transform.parent.localScale.x == -1)
        {
            bulletScript.bulletOffset = -bulletOffset;
            bulletScript.bulletDirection = transform.right * 10;
            Debug.Log(transform.right);
        }
        else
        {
            bulletScript.bulletOffset = bulletOffset;
            bulletScript.bulletDirection = transform.right * -10;
            Debug.Log(transform.right);
        }

        bulletScript.enabled = true;
    }
    public bool StartShooting()
    {
        if (canShoot == false || isShooting == true)
            return false;

        isShooting = true;
        return true;
    }

    public void StopShooting()
    {
        if (isShooting == false)
            return;

        isShooting = false;
        bulletCooldown = 0;
    }
}
