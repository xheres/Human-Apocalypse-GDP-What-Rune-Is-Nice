using UnityEngine;
using System.Collections;

public class EnemyProperties : MonoBehaviour 
{
    public int maxAmmo;
    public GameObject muzzle;
    public float spawnedYPos;
    public enum muzzleType { aimed, pattern };
    public enum enemyType { standard, miniboss, mainboss };
    
    public void UseAmmo() { maxAmmo -= 1; }
    }
