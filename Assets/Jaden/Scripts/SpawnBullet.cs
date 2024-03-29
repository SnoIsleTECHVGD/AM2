using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnBullet : MonoBehaviour
{
    public GameObject bullet;
    public Vector3 mousePos;
    public GameObject theCamera;
    public Vector3 HELPPP;
    public int speed;
    public bool canShoot = true;
    public GameObject player;
    void Update()
    {
        HELPPP = Input.mousePosition;
        mousePos = theCamera.transform.GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
        
        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            StartCoroutine(ewaewaah());
        }
    }

    IEnumerator ewaewaah()
    {
        canShoot = false;
        player.GetComponent<Animator>().SetBool("IsShooting", true);
        yield return new WaitForSeconds(0.2f);
        Vector2 target = theCamera.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 direction = target - myPos;
        direction.Normalize();
        Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180);
        GameObject projectile = Instantiate(bullet, transform.position, rotation);
        projectile.SetActive(true);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 5 * speed;
        yield return new WaitForSeconds(0.2f);
        player.GetComponent<Animator>().SetBool("IsShooting", false);
        canShoot = true;
    }
}
