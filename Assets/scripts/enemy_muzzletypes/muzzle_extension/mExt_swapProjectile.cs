using UnityEngine;
using System.Collections;

public class mExt_swapProjectile : MonoBehaviour 
{
    [SerializeField] GameObject projectileToSwap;
    [SerializeField] bool swapAfter = true;

    muzzle_generic muzzle;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        if (swapAfter)
        {
            muzzle.After += swapProjectile;
        }
        else
        {
            muzzle.Before += swapProjectile;
        }
    }

    void OnDisable()
    {
        if (swapAfter)
        {
            muzzle.After -= swapProjectile;
        }
        else
        {
            muzzle.Before -= swapProjectile;
        }
    }

    void swapProjectile()
    {
        muzzle.setProjectile(projectileToSwap);
    }
}
