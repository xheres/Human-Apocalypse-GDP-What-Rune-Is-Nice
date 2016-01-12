using UnityEngine;
using System.Collections;

public class projectile_linear : MonoBehaviour 
{
    [SerializeField] float speed = 0;
    [SerializeField] float maxSpeed = 0;
    [SerializeField] float accelerationTime = 0;
    [SerializeField] float accelerationDelay = 0;
    [SerializeField] float tangentialSpeed = 0;
    [SerializeField] float trackingRange = 0;
    [SerializeField] float trackingRotSpeed = 0;
    [SerializeField] float duration = 0;

    public delegate void otherBehaviors();
    public event otherBehaviors before;
    public event otherBehaviors within;
    //public event otherBehaviors after; // do we need this?

    bool beforeDoneFlag = false;
    float initSpeed = 0;
    float rotAngle;

    Transform myTransform;
    Transform playerTransform;
    Vector3 diff;
    Quaternion rotation;
    RaycastHit2D hit;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        myTransform = transform;
        initSpeed = speed;
        rotAngle = myTransform.localRotation.z;

        if(maxSpeed < speed)
        {
            maxSpeed = speed;
        }
    }

    void Update()
    {
        duration -= Time.deltaTime;

        // Destroy projectile if ran out of time
        if(duration <= 0)
        {
            Destroy(gameObject);
        }

        // Destroy projectile if went out of bounds
        if(myTransform.position.y <= -5 || myTransform.position.y >= 12 || myTransform.position.x <= -8 || myTransform.position.x >= 8)
        {
            Destroy(gameObject);
        }

        // Run before behavior
        if(before != null)
        {
            before();
        }

        // Handle projectile stuff after before behavior is done
        else
        {
            // Handle other behaviors within the movement
            if(within != null)
            {
                within();
            }

            myTransform.Translate(0, -speed * Time.deltaTime, 0); // Apply forward movement (-transform.up cuz we're moving down)

            // Handle Acceleration
            if (accelerationTime > 0 && speed < maxSpeed)
            {
                if (accelerationDelay > 0)
                {
                    accelerationDelay -= Time.deltaTime;
                }
                else
                {
                    StartCoroutine("Accelerate");
                }
            }
            else if (speed >= maxSpeed)
            {
                speed = maxSpeed;
                StopCoroutine("Accelerate");
            }

            //Handle Tangential movement;
            if (tangentialSpeed != 0)
            {
                myTransform.RotateAround(myTransform.position + (Vector3.right * speed / tangentialSpeed), Vector3.forward, tangentialSpeed * Time.deltaTime);
            }

            //Handle tracking;
            if(trackingRange > 0)
            {
                if(Vector2.Distance(playerTransform.position, myTransform.position) <= trackingRange)
                {
                    diff = (-(playerTransform.position - myTransform.position));
                    float zRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
                    rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

                    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * (trackingRotSpeed * 0.1f));
                }
            }
        }
    }

    //hit player
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("hit"); //Apply Damage
            Destroy(gameObject);
        }
    }

    // Accelerate Projectile
    IEnumerator Accelerate()
    {
        speed += (maxSpeed - initSpeed) / (accelerationTime/Time.deltaTime);
        yield return null;
    }

    public void beforeDone()
    {
        beforeDoneFlag = true;
    }
}
