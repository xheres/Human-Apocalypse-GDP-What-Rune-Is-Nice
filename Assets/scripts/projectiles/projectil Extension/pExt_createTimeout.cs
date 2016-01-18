using UnityEngine;
using System.Collections;

public class pExt_createTimeout : MonoBehaviour 
{
    projectile_linear projectile;

    [SerializeField] GameObject muzzleCreator;

    void Awake()
    {
        projectile = GetComponent<projectile_linear>();
    }

    void OnEnable()
    {
        projectile.After += createMuzzle;
    }

    void OnDisable()
    {
        projectile.After -= createMuzzle;
    }

    void createMuzzle()
    {
        Instantiate(muzzleCreator, transform.position, Quaternion.identity);
    }
}
