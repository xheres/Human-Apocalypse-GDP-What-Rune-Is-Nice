using UnityEngine;
using System.Collections;

public class PatternA : MonoBehaviour 
{
    [SerializeField] float delay = 1;
    [SerializeField] GameObject[] spawner;
    GameObject obj;

	void Start () 
    {
        StartCoroutine("CreateSpawner");
	}
	
	IEnumerator CreateSpawner()
    {
        for (int i = 0; i < spawner.Length; i++)
        {
            obj = Instantiate(spawner[i], transform.position, Quaternion.identity) as GameObject;
            obj.transform.SetParent(transform);
            yield return new WaitForSeconds(delay);
        }
        yield return null;
    }
}
