using UnityEngine;
using System.Collections;

public class mExt_aimed : MonoBehaviour 
{
    muzzle_generic muzzle;
    Transform myTransform;
    Transform playerTransform;

    Vector3 diff;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = transform;
    }

    void OnEnable()
    {
        muzzle.Before += aimPlayer;
    }

    void OnDisable()
    {
        muzzle.Before -= aimPlayer;
    }

    void aimPlayer()
    {
        diff = (-(playerTransform.position - myTransform.position)).normalized;
        float zRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        muzzle.setRotation(Quaternion.Euler(0, 0, zRotation - 90));
    }
}
