using UnityEngine;
using System.Collections;

public class SatelliteController : MonoBehaviour 
{
    //public GameObject warningSign;
    [SerializeField]private GameObject laser;
    //public GameObject area;
    private float initLaserCooldown = 60;
    //private float initAreaCooldown;

    private GameObject warning;
    private float playerPos;
    private float laserCooldown;
    //private float areaCooldown;

    void Start()
    {
        laserCooldown = initLaserCooldown;
        //areaCooldown = initAreaCooldown;
    }

	void Update () 
    {
        playerPos = GameObject.Find("Player").transform.position.x;
        transform.position = new Vector2(playerPos, 5.0f);

        laserCooldown -= Time.deltaTime;
        if (laserCooldown % 60 < 0)
        {
            FireLaser();
            laserCooldown = initLaserCooldown;   
        }
	}

    void FireLaser()
    {
        //warning = Instantiate(warningSign, new Vector3(transform.position.x, 8.5f), Quaternion.identity) as GameObject;
        Invoke("CreateLaser", 1.5f);
    }

    void CreateLaser()
    {
        Instantiate(laser, transform.position, Quaternion.identity);
        //Instantiate(laser, warning.transform.position, Quaternion.identity);
    }
}
