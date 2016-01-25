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
        trPos = new Vector2(2.7f, 8.7f);
        tlPos = new Vector2(-2.7f, 8.7f);
        brPos = new Vector2(2.7f, -0.7f);
        blPos = new Vector2(-2.7f, -0.7f);


        Invoke("CreateLeft", 0f);
        Invoke("CreateRight", 1f);
	}

    void CreateLeft()
    {
        Instantiate(muzzleC[0], tlPos, Quaternion.identity);
        Instantiate(muzzleC[3], blPos, Quaternion.identity);
        Invoke("CreateLeftDelayed", 7.5f);
    }

    void CreateRight()
    {
        Instantiate(muzzleC[6], trPos, Quaternion.identity);
        Instantiate(muzzleC[9], brPos, Quaternion.identity);
        Invoke("CreateRightDelayed", 5.5f);
    }

    void CreateLeftDelayed()
    {
        Instantiate(muzzleC[1], tlPos, Quaternion.identity);
        Instantiate(muzzleC[4], blPos, Quaternion.identity);
        StartCoroutine(LastLeftDelayed());
    }

    void CreateRightDelayed()
    {
        Instantiate(muzzleC[7], trPos, Quaternion.identity);
        Instantiate(muzzleC[10], brPos, Quaternion.identity);
        StartCoroutine(LastRightDelayed());
    }

    IEnumerator LastLeftDelayed()
    {
        yield return new WaitForSeconds(4.75f);
        Instantiate(muzzleC[5], blPos, Quaternion.identity);
        Instantiate(muzzleC[2], tlPos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(muzzleC[5], blPos, Quaternion.identity);
        Instantiate(muzzleC[2], tlPos, Quaternion.identity);
        yield return null;
    }

    IEnumerator LastRightDelayed()
    {
        yield return new WaitForSeconds(6.75f);
        Instantiate(muzzleC[11], brPos, Quaternion.identity);
        Instantiate(muzzleC[8], trPos, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        Instantiate(muzzleC[11], brPos, Quaternion.identity);
        Instantiate(muzzleC[8], trPos, Quaternion.identity);
        yield return null;
    }
}
