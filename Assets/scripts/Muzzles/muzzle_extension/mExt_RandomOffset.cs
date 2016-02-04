using UnityEngine;
using System.Collections;

public class mExt_RandomOffset : MonoBehaviour {

    muzzle_generic muzzle;
    float rand, randDeci;
    Vector3 offset;

    void Awake()
    {
        muzzle = GetComponent<muzzle_generic>();
    }

    void OnEnable()
    {
        muzzle.BeforeCreate += setOffset;
    }

    void OnDisable()
    {
        muzzle.After -= setOffset;
    }

    void setOffset()
    {
        rand = Random.Range(-2.0f, 2.0f);
        Mathf.Round(rand);
        randDeci = Random.Range(-0.2f, 0.2f);
        offset = muzzle.getOffset();
        if (offset.x < rand)
        {
            muzzle.setOffset(new Vector3(offset.x - rand - randDeci, offset.y));
        }
        else if (offset.x > 0.5f)
        {
            muzzle.setOffset(new Vector3(offset.x + rand + randDeci, offset.y));
        }
    }
}

