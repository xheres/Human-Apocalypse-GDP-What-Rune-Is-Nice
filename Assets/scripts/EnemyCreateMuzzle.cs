using UnityEngine;
using System.Collections;

public class EnemyCreateMuzzle : MonoBehaviour 
{
    bool muzzleDeleted = true;
    EnemyProperties enemyProp;

    public void deleteMuzzle() { muzzleDeleted = true; }

    void Start()
    {
        enemyProp = GetComponent<EnemyProperties>();
    }

	void Update() 
    {
	    if (!isSpawning() && !isExiting() && muzzleDeleted)
        {
            Invoke("CreateMuzzle", enemyProp.getReloadTime());
            muzzleDeleted = false;
        }
	}

    void CreateMuzzle()
    {
        GameObject newMuzzle = Instantiate(enemyProp.getMuzzle(), transform.position, Quaternion.identity) as GameObject;
        newMuzzle.transform.parent = transform;
    }

    bool isExiting()
    {
        if (enemyProp.getAmmo() <= 0 && enemyProp.getAmmo() != -99) // Exit when enemy runs out of bullet (-99 is for debugging)
        {
            return true;
        }
        return false;      
    }

    bool isSpawning() // Is enemy in position?
    {
        if (transform.position.y > enemyProp.getSpawnedYPos() + 1f)
        {
            return true;
        }
        return false;
    }
}
