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

            int layerMask = LayerMask.GetMask("Player");
            RaycastHit2D cast = Physics2D.Raycast(transform.position, targetTransform.position - transform.position, maxDetectionRange, layerMask);

            if (cast.transform == targetTransform)
            {
                hasSeenPlayer = true;
            }
        } else
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
        }
    }
    
}
