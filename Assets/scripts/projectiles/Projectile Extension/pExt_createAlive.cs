using UnityEngine;
using System.Collections;

public class pExt_createAlive : MonoBehaviour 
{
    projectile_linear projectile;

    [SerializeField] GameObject muzzleCreator;

    void Awake()
    {
        projectile = GetComponent<projectile_linear>();
    }

    void OnEnable()
    {
        projectile.OnStart += createMuzzle;
    }

    void OnDisable()
    {
        projectile.OnStart -= createMuzzle;
    }

    void createMuzzle()
    {
        GameObject createdMuzzleC = Instantiate(muzzleCreator, transform.position, Quaternion.identity) as GameObject;
        createdMuzzleC.transform.SetParent(transform);
    }
}
