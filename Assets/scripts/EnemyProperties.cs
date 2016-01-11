using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour
{
    [SerializeField] GameObject muzzle;
    [SerializeField] GameObject projectile;
    [SerializeField] float spawnedYPos = 6.5f;
    [SerializeField] int maxAmmo = -99;
    [SerializeField] int shotsPerRound;
    [SerializeField] float interval;
    [SerializeField] float reloadTime;
    //public enum muzzleType { aimed, pattern };
    //public enum enemyType { standard, miniboss, mainboss };

    void Update()
    {
        //Debug.Log(maxAmmo);
    }

    public void UseAmmo()
    {
        maxAmmo -= 1;
    }
    public int getAmmo()
    {
        return maxAmmo;
    }
    public float getSpawnedYPos()
    {
        return spawnedYPos;
    }
    public int getShotsPerRound()
    {
        return shotsPerRound;
    }
    public float getInterval()
    {
        return interval;
    }
    public float getReloadTime()
    {
        return reloadTime;
    }
    public GameObject getMuzzle()
    {
        return muzzle;
    }
    public GameObject getProjectile()
    {
        return projectile;
    }
    public void setMuzzle(GameObject Muzzle)
    {
        muzzle = Muzzle;
    }
    public void useShotsPerRound(int i)
    {
        shotsPerRound -= i;
    }
}