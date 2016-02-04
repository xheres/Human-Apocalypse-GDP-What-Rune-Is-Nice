using UnityEngine;
using System.Collections;

public class Boss04Movement : MonoBehaviour
{
    Transform player;
    public float movespeed;

    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
    }

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        player = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(player.transform.position.x * movespeed, transform.position.y, transform.position.z);


    }
}
