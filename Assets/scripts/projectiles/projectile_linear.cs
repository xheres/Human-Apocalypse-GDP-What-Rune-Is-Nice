using UnityEngine;
using System.Collections;

public class projectile_linear : MonoBehaviour 
{
    [SerializeField] float speed = 0;
    [SerializeField] float endSpeed = 0;
    [SerializeField] float accelerationTime = 0;
    [SerializeField] float accelerationDelay = 0;
    [SerializeField] float tangentialSpeed = 0;
    [SerializeField] float trackingRange = 0;
    [SerializeField] float trackingRotSpeed = 0;
    [SerializeField] float duration = 0;

    public delegate void otherBehaviors();
    public event otherBehaviors Before;
    public event otherBehaviors Within;
    public event otherBehaviors After;

    bool beforeDoneFlag = true;
    float initSpeed = 0;

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
    }

    void Update()
    {
        duration -= Time.deltaTime;

        // Destroy projectile if ran out of time
        if(duration <= 0)
        {
            if (After != null)
            {
                After();
            }
            Destroy(gameObject);
        }

        // Destroy projectile if went out of bounds
        if(myTransform.position.y <= -5 || myTransform.position.y >= 12 || myTransform.position.x <= -8 || myTransform.position.x >= 8)
        {
            Destroy(gameObject);
        }

        // Run before behavior
        if(Before != null)
        {
            beforeDoneFlag = false;
            Before();
        }

        // Handle projectile stuff after before behavior is done
        else
        {
            if (beforeDoneFlag)
            {
                // Handle other behaviors within the movement
                if (Within != null)
                {
                    Within();
                }

                myTransform.Translate(0, -speed * Time.deltaTime, 0); // Apply forward movement (-transform.up cuz we're moving down)

                // Handle Acceleration
                if (accelerationTime > 0)
                {
                    if (accelerationDelay > 0)
                    {
                        accelerationDelay -= Time.deltaTime;
                    }
                    else
                    {
                        StartCoroutine("Accelerate");
                        if (initSpeed > endSpeed && speed < endSpeed)
                        {
                            speed = endSpeed;
                            StopCoroutine("Accelerate");
                        }
                        else if (initSpeed < endSpeed && speed > endSpeed)
                        {
                            speed = endSpeed;
                            StopCoroutine("Accelerate");
                        }
                    }
                }

                //Handle Tangential movement;
                if (tangentialSpeed != 0)
                {
                    myTransform.RotateAround(myTransform.position + (Vector3.right * speed / tangentialSpeed), Vector3.forward, tangentialSpeed * Time.deltaTime);
                }

                //Handle tracking;
                if (trackingRange > 0)
                {
                    if (Vector2.Distance(playerTransform.position, myTransform.position) <= trackingRange)
                    {
                        diff = (-(playerTransform.position - myTransform.position));
                        float zRotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg - 90;
                        rotation = Quaternion.AngleAxis(zRotation, Vector3.forward);

                        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * (trackingRotSpeed * 0.1f));
                    }
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
        if (endSpeed > speed)
        {
            speed += (endSpeed - initSpeed) / (accelerationTime / Time.deltaTime);
        }
        else if (speed > endSpeed)
        {
            speed -= (initSpeed - endSpeed) / (accelerationTime / Time.deltaTime);
        }
        yield return null;
    }

    public void beforeDone()
    {
        beforeDoneFlag = true;
    }

    public void setProperties(float spd, float eSpd, float accelTime, float accelDelay, float tanSpeed, float trackRange, float trackSpeed, float dura)
    {
        speed = spd;
        endSpeed = eSpd;
        accelerationTime = accelTime;
        accelerationDelay = accelDelay;
        tangentialSpeed = tanSpeed;
        trackingRange = trackRange;
        trackingRotSpeed = trackSpeed;
        duration = dura;
    }
}