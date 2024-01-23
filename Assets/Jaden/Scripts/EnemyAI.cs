using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;
    public GameObject weaponGrip;

    public float maxDetectionRange = 20f;
    public bool hasSeenPlayer = false;

    private Stats targetStats;
    private Transform targetTransform;

    private Stats myStats;
    public EnemyGun myGun;

    public bool hasDrawn = false;
    public int ez = 1;
    void Start()
    {
        myStats = GetComponent<Stats>();

        targetTransform = target.transform;
        targetStats = target.GetComponent<Stats>();
    }

    void Update()
    {
        

        if (hasSeenPlayer == false)
        {
            myGun.StopShooting();
            GetComponent<Animator>().SetBool("IsShooting", false);
            int layerMask = LayerMask.GetMask("Player");
            RaycastHit2D cast = Physics2D.Raycast(transform.position, targetTransform.position - transform.position, maxDetectionRange, layerMask);

            if (cast.transform == targetTransform)
            {
                if (ez == 0)
                {
                    hasSeenPlayer = true;
                    GetComponent<Animator>().SetBool("canSee", false);
                    ez = 1;
                }
                else
                {
                    Debug.Log(ez);
                    hasSeenPlayer = true;
                    GetComponent<Animator>().SetBool("canSee", false);
                }
            }
        } 
        else
        {
            if (transform.localScale.x == -1)
            {
                // Gun facing right (doesnt work)
                weaponGrip.transform.right = -(weaponGrip.transform.position - targetTransform.position);
            }
            else
            {
                // Gun facing left
                weaponGrip.transform.right = -(targetTransform.position - weaponGrip.transform.position);
            }

            myGun.StartShooting();
            GetComponent<Animator>().SetBool("IsShooting", true);
        }
    }
}
