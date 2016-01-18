using UnityEngine;
using System.Collections;

public class mExt_noOffset : MonoBehaviour 
{
    muzzle_generic muzzle;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        muzzle.BeforeCreate += resetOffset;
    }

    void OnDisable()
    {
        muzzle.BeforeCreate -= resetOffset;
    }

    void resetOffset()
    {
        muzzle.setOffset(transform.position);
    }
}
