using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour 
{
    [SerializeField]private GameObject muzzle;
    [SerializeField]private float spawnedYPos = 6.5f;
    [SerializeField]private int maxAmmo = -1;
    //public enum muzzleType { aimed, pattern };
    //public enum enemyType { standard, miniboss, mainboss };
    
    public void UseAmmo() { maxAmmo -= 1; }
    public int getAmmo() { return maxAmmo;  }
    public float getSpawnedYPos() { return spawnedYPos; }
    public GameObject getMuzzle() { return muzzle;  }
    public void setMuzzle(GameObject Muzzle) {muzzle = Muzzle;}
    }
