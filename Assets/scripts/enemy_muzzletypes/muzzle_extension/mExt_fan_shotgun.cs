using UnityEngine;
using System.Collections;

public class mExt_fan_shotgun : MonoBehaviour 
{
    muzzle_generic muzzle;

    [SerializeField] float angleDiff = 0;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        muzzle.Before += rotateMuzzle;
        muzzle.After += resetRotation;
    }

    void OnDisable()
    {
        muzzle.Before -= rotateMuzzle;
        muzzle.After -= resetRotation;
    }

    void rotateMuzzle()
    {
        muzzle.setRotation(Quaternion.Euler(0, 0, muzzle.getRotation().eulerAngles.z + angleDiff));
    }

    void resetRotation()
    {
        muzzle.setRotation(Quaternion.Euler(muzzle.getInitRotation()));
    }
}
