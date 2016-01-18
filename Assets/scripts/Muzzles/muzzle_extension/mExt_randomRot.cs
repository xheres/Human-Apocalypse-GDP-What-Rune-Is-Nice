using UnityEngine;
using System.Collections;

public class mExt_randomRot : MonoBehaviour 
{
    muzzle_generic muzzle;
    int rand;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        muzzle.BeforeCreate += changeRotation;
    }

    void OnDisable()
    {
        muzzle.BeforeCreate -= changeRotation;
    }

    void changeRotation()
    {
        muzzle.setRotation(Quaternion.Euler(0, 0, Random.value * 360));
    }
}
