using UnityEngine;
using System.Collections;

public class muzzle_aimed : MonoBehaviour 
{
    [SerializeField]private GameObject projectile;
    [SerializeField]private int shotsPerRound;
    [SerializeField]private float interval;
    private EnemyProperties enemyProp;

    private bool shotFired = false;

    void Start()
    {
        enemyProp = GetComponentInParent<EnemyProperties>();
    }
	void Update () 
    {
        if (enemyProp.getAmmo() != 0)
        {
            if (shotsPerRound != 0 && !shotFired)
            {
                Invoke("createProjectile", interval);
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
        Instantiate(projectile, transform.position, Quaternion.identity);
        if (enemyProp.getAmmo() != -1)
            enemyProp.UseAmmo();
        shotsPerRound -= 1;
        shotFired = false;

        Debug.Log("Created");
    }
}
