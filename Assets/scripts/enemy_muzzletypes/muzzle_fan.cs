using UnityEngine;
using System.Collections;

public class muzzle_fan : MonoBehaviour 
{
    public GameObject projectile;
    public int shotsPerRound;
    public float interval;

    private float zRotation = -50;
    private bool shotFired = false;
    private bool leftSweep = false;
    private bool rightSweep = false;
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (GetComponentInParent<EnemyProperties>().maxAmmo != 0)
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
        if (GetComponentInParent<EnemyProperties>().maxAmmo != -1)
            GetComponentInParent<EnemyProperties>().UseAmmo();
        shotsPerRound -= 1;
        shotFired = false;  
    }

    void changeRotation()
    {

        if (zRotation >= 50)
        {
            rightSweep = false;
            leftSweep = true;
        }

        if (zRotation <= -50)
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

