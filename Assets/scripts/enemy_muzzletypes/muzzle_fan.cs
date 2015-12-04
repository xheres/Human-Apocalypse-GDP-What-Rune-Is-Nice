using UnityEngine;
using System.Collections;

public class muzzle_fan : MonoBehaviour 
{
    [SerializeField]private GameObject projectile;
    [SerializeField]private int shotsPerRound = 30;
    [SerializeField]private float interval = 0.2f;

    private float zRotation = -60;
    private bool shotFired = false;
    private bool leftSweep = false;
    private bool rightSweep = false;

    private EnemyProperties enemyProp;

	void Start()
    {
        enemyProp = GetComponentInParent<EnemyProperties>();
    }
	void Update () 
    {
        if (enemyProp.getAmmo() <= 0 || enemyProp.getAmmo() == -1)
        {
            if (shotsPerRound != 0 && !shotFired)
            {
                Invoke("createProjectile", interval);
                changeRotation();
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
        Instantiate(projectile, transform.position, Quaternion.Euler(0,0,zRotation));
        if (enemyProp.getAmmo() != -1)
            enemyProp.UseAmmo();
        shotsPerRound -= 1;
        shotFired = false;  
    }

    void changeRotation()
    {

        if (zRotation >= 60)
        {
            rightSweep = false;
            leftSweep = true;
        }

        if (zRotation <= -60)
        {
            leftSweep = false;
            rightSweep = true;
        }
        if (leftSweep == true)
        {
            zRotation -= 5;
        }

        if (rightSweep == true)
        {
            zRotation += 5;
        }
    }
}

