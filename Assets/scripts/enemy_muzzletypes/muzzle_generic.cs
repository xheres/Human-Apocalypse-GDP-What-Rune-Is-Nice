using UnityEngine;
using System.Collections;

public class muzzle_generic : MonoBehaviour 
{
    EnemyProperties enemyProp;
    GameObject projectile;
    Quaternion rotation;

    [SerializeField] int projectilesPerShot = 1;
    [SerializeField] Vector3 initRotation;
    [SerializeField] Vector2 projectileOffset;

    int shotsPerRound;

    public delegate void controlRotation();
    public event controlRotation After;
    public event controlRotation Before;

    bool shotFired = false;
    bool ammoTaken = false;
    float interval;

    void Start()
    {
        enemyProp = GetComponentInParent<EnemyProperties>();
        projectile = enemyProp.getProjectile();
        shotsPerRound = enemyProp.getShotsPerRound();
        rotation = Quaternion.Euler(initRotation);

        interval = enemyProp.getInterval();

        projectileOffset += (Vector2)transform.position;
    }

    void Update()
    {
        if (enemyProp.getAmmo() > 0)
        {
            if (shotsPerRound > 0 && !shotFired)
            {
                for (int i = 0; i < projectilesPerShot; i++)
                {
                    Invoke("createProjectile", interval);
                    shotFired = true;
                }

                ammoTaken = false;

                if (After != null)
                {

                    After();
                }
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
        if (Before != null)
        {
            Before();
        }

        Instantiate(projectile, projectileOffset, rotation);

        if (!ammoTaken)
        {
            if (enemyProp.getAmmo() != -99)
            {
                enemyProp.UseAmmo();
            }

            shotsPerRound -= 1;

            ammoTaken = true;
        }

        shotFired = false;
    }

    public void setRotation(Quaternion q)
    {
        rotation = q;
    }

    public void setProjectileOffset(Vector2 v)
    {
        projectileOffset = v;
    }

    public Quaternion getRotation()
    {
        return rotation;
    }

    public Vector3 getInitRotation()
    {
        return initRotation;
    }

    public int getProjectilesPerShot()
    {
        return projectilesPerShot;
    }

    public Vector2 getProjectileOffset()
    {
        return projectileOffset;
    }
}
