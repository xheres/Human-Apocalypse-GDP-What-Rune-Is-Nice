using UnityEngine;
using System.Collections;

public class muzzle_aimed : MonoBehaviour 
{
    EnemyProperties enemyProp;
    GameObject projectile;
    Transform playerTransform;
    Transform myTransform;

    int shotsPerRound;
    int projectileIndex;

    Vector3 diff;
    bool shotFired = false;

    void Start()
    {
        enemyProp = GetComponentInParent<EnemyProperties>();
        projectile = enemyProp.getProjectile();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = transform;

        shotsPerRound = enemyProp.getShotsPerRound();
    }
	void Update () 
    {
        if (enemyProp.getAmmo() != 0)
        {
            if (shotsPerRound != 0 && !shotFired)
            {
                Invoke("createProjectile", enemyProp.getInterval());
                shotFired = true;
            }
            else if (shotsPerRound <= 0)
            {
                GetComponentInParent<EnemyCreateMuzzle>().deleteMuzzle();
                Destroy(gameObject);
            }
        }
	}

    void createProjectile()
    {
        diff = (-(playerTransform.position - myTransform.position)).normalized;
        float zRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, zRotation - 90));
        if (enemyProp.getAmmo() != -99)
            enemyProp.UseAmmo();
        shotsPerRound -= 1;
        shotFired = false;
    }
}
