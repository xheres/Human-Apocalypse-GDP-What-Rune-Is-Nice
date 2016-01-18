using UnityEngine;
using System.Collections;

public class mExt_fan_shotgun : MonoBehaviour 
{
    muzzle_generic muzzle;

    [SerializeField] float angleDiff = 0;
    [SerializeField] bool resetAfter;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        muzzle.Before += rotateMuzzle;
        if (resetAfter)
        {
            muzzle.After += resetRotation;
        }
    }

    void OnDisable()
    {
        muzzle.Before -= rotateMuzzle;
        if (resetAfter)
        {
            muzzle.After -= resetRotation;
        }
    }

    void rotateMuzzle()
    {
        muzzle.setRotation(Quaternion.Euler(0, 0, muzzle.getRotation().eulerAngles.z + angleDiff));
    }

    void resetRotation()
    {
        muzzle.setRotation(Quaternion.Euler(new Vector3(0, 0, muzzle.getZRotation())));
    }
}
