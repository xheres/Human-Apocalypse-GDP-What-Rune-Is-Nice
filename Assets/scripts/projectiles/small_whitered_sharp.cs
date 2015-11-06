using UnityEngine;
using System.Collections;

public class small_whitered_sharp : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
            
    }

    void Update()
    {
        if (transform.position.y < -4 || transform.position.x > 5 || transform.position.x < -5)
            Destroy(gameObject);
    }

    void FixedUpdate()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
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
