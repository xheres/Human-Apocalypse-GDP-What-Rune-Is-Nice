using UnityEngine;
using System.Collections;

public class small_whitered_aimed : MonoBehaviour 
{

    public float speed = 100;

    Rigidbody2D rb;
    Vector3 playerPos;
	// Use this for initialization
	void Start () 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPos = player.transform.position;
        rb = GetComponent<Rigidbody2D>();

        // Shoot towards the player's position
        // not the current(moving) position, but when the projectile is spawned
        rb.AddForce(-Vector3.Normalize(transform.position - playerPos) * speed);
	}

    void Update()
    {
        if (transform.position.y < -4 || transform.position.x > 5 || transform.position.x < -5)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Hit"); // Apply damage here (link player properties object to projectile and run the deduct hp func)
            Destroy(gameObject);
        }

    }
}
