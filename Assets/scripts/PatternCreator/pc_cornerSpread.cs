using UnityEngine;
using System.Collections;

public class pc_cornerSpread : MonoBehaviour 
{
    [SerializeField] GameObject[] muzzleC = new GameObject[12];

    Vector3 trPos;
    Vector3 tlPos;
    Vector3 brPos;
    Vector3 blPos;

	void Start () 
    {
        trPos = new Vector2(4.7f, 8.7f);
        tlPos = new Vector2(-4.7f, 8.7f);
        brPos = new Vector2(4.7f, -0.7f);
        blPos = new Vector2(-4.7f, -0.7f);


        Invoke("CreateLeft", 0f);
        Invoke("CreateRight", 0.5f);
	}

    void CreateLeft()
    {
        Instantiate(muzzleC[0], tlPos, Quaternion.identity);
        Instantiate(muzzleC[3], blPos, Quaternion.identity);
        //Invoke leftDelayed
    }

    void CreateRight()
    {
        Instantiate(muzzleC[6], trPos, Quaternion.identity);
        Instantiate(muzzleC[9], brPos, Quaternion.identity);
        //Invoke rightDelayed
    }

    void CreateLeftDelayed()
    {
    
    }

    void CreateRightDelayed()
    {
    
    }
	
}
