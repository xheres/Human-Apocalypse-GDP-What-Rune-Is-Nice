﻿using UnityEngine;
using System.Collections;

public class muzzle_generic : MonoBehaviour 
{
    EnemyProperties enemyProp;
    GameObject projectile;
    GameObject createdProjectile;
    Quaternion rotation;

    [SerializeField] int projectilesPerShot = 1;
    [SerializeField] float initRotation;
    [SerializeField] Vector2 projectileOffset;

    int shotsPerRound;

    public delegate void controlRotation();
    public event controlRotation After;
    public event controlRotation Before;

    float interval;
    float zRotation;
    float prevZRotation;

    void Start()
    {
        enemyProp = GetComponentInParent<EnemyProperties>();
        projectile = enemyProp.getProjectile();
        shotsPerRound = enemyProp.getShotsPerRound();
        prevZRotation = enemyProp.getPrevZRotation();
        if(prevZRotation == 0)
        {
            rotation = Quaternion.Euler(new Vector3(0, 0, initRotation));
            zRotation = initRotation;
        }
        else
        {
            rotation = Quaternion.Euler(new Vector3(0, 0, prevZRotation));
            zRotation = prevZRotation;
        }
        

        interval = enemyProp.getInterval();

        projectileOffset += (Vector2)transform.position;

        StartCoroutine(ShootProjectile());
    }

    IEnumerator ShootProjectile()
    {
        while (enemyProp.getAmmo() > 0)
        {
            if (shotsPerRound > 0)
            {
                //shotFired = true;
                for (int i = 0; i < projectilesPerShot; i++)
                {
                    CreateProjectile();
                }

                if (After != null)
                {
                    After();
                }

                if (enemyProp.getAmmo() != -99)
                {
                    enemyProp.UseAmmo();
                }

                shotsPerRound -= 1;

            }
            else if (shotsPerRound <= 0)
            {
                enemyProp.setPrevZRotation(rotation.eulerAngles.z);
                GetComponentInParent<EnemyCreateMuzzle>().deleteMuzzle();
                Destroy(gameObject);
            }
        yield return new WaitForSeconds(interval);
        }
    }

    void CreateProjectile()
    {
        createdProjectile = Instantiate(projectile, projectileOffset, rotation) as GameObject;

        if (Before != null)
        {
            Before();
        }
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

    public float getInitRotation()
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

    public GameObject getCreatedProjectile()
    {
        return createdProjectile;
    }

    public void setProjectile(GameObject proj)
    {
        projectile = proj;
    }

    public void setPrevZRotation(float z)
    {
        prevZRotation = z;
    }

    public void setZRotation(float z)
    {
        zRotation = z;
    }

    public float getZRotation()
    {
        return zRotation;
    }
}