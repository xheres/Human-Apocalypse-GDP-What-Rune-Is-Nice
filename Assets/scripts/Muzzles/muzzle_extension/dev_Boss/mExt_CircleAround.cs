using UnityEngine;
using System.Collections;

public class mExt_CircleAround : MonoBehaviour 
{
    [SerializeField] float radius;
    [SerializeField] float angle;
    [SerializeField] float angleAdded;

    muzzle_generic muzzle;
    Transform myTransform;
    Vector2 offset;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
        myTransform = transform;
    }

    void OnEnable()
    {
        muzzle.Before += AddAngle;
    }

    void OnDisable()
    {
        muzzle.Before -= AddAngle;
    }

    void AddAngle()
    {
        offset = new Vector2((myTransform.position.x + radius * Mathf.Cos(angle * Mathf.PI/180)), (myTransform.position.y + radius * Mathf.Sin(angle * Mathf.PI/180)));
        muzzle.setProjectileOffset(offset);
        angle += angleAdded;
    }
}
