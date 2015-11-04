using UnityEngine;
using System.Collections;

public class muzzle_aimed : MonoBehaviour 
{
    public GameObject projectile;
    public int shotsPerRound;
    public float interval;

    private bool shotFired = false;
	void Update () 
    {
        if (GetComponentInParent<EnemyProperties>().maxAmmo != 0)
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
        if (GetComponentInParent<EnemyProperties>().maxAmmo != -1)
            GetComponentInParent<EnemyProperties>().UseAmmo();
        shotsPerRound -= 1;
        shotFired = false;        
    }
}
