using UnityEngine;
using System.Collections;

public class laserProjectile : MonoBehaviour 
{
    public float laserDuration = 0.75f;

    void Start()
    {
        Invoke("DestroyLaser", laserDuration);
    }

    void DestroyLaser()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Apply damage
            Debug.Log("Laser Hit");
        }
    }
}
