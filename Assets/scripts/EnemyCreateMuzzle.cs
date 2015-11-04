using UnityEngine;
using System.Collections;

public class EnemyCreateMuzzle : MonoBehaviour 
{

    public float reloadTime;

    private bool muzzleDeleted = true;

    public void deleteMuzzle() { muzzleDeleted = true; }


	void Update() 
    {
        Debug.Log(muzzleDeleted);
	    if (!isSpawning() && !isExiting() && muzzleDeleted)
        {
            Invoke("CreateMuzzle", reloadTime);
            muzzleDeleted = false;
        }
	}

    void CreateMuzzle()
    {
        GameObject newMuzzle = (GameObject)Instantiate(GetComponent<EnemyProperties>().muzzle, transform.position, Quaternion.identity);
        newMuzzle.transform.parent = gameObject.transform;
    }

    bool isExiting()
    {
        if (GetComponent<EnemyProperties>().maxAmmo <= 0 && GetComponent<EnemyProperties>().maxAmmo != -1) // Exit when enemy runs out of bullet
        {
            Debug.Log("Exiting");
            return true;
        }
        return false;      
    }

    bool isSpawning() // Is enemy in position?
    {
        if (gameObject.transform.position.y > GetComponent<EnemyProperties>().spawnedYPos)
        {
            Debug.Log("Spawning");
            return true;
        }
        return false;
    }
}
