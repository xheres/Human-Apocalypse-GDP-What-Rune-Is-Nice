using UnityEngine;
using System.Collections;

public class mExt_fan_consec : MonoBehaviour 
{
    muzzle_generic muzzle;

    [SerializeField] float angleDiff = 0;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        muzzle.After += rotateMuzzle;
    }

    void OnDisable()
    {
        muzzle.After += rotateMuzzle;
    }

    void rotateMuzzle()
    {
        muzzle.setRotation(Quaternion.Euler(0, 0, muzzle.getRotation().eulerAngles.z + angleDiff));
    }
}
