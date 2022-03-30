using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPigMove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5.0f;
    public float maxVelocity = 3.0f;
    public float cicleTime = 20.0f;

    private Animator anim;
    private Rigidbody body;
    private float prevTime = 0.0f;
    private int direction = 1;
    private bool isMoving = false;

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        body = gameObject.GetComponent<Rigidbody>();
        prevTime = Time.time;
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - prevTime > cicleTime)
        {
            direction = Random.Range(1, 5);
            isMoving = Random.Range(0, 2) == 1 ? true : false;
            anim.SetInteger("direction", direction);
            anim.SetBool("isMoving", isMoving);
            prevTime = Time.time;
        }
        if (isMoving)
        {
            switch (direction)
            {
                case 1:
                    body.AddForce(Vector3.back * speed);
                    break;
                case 2:
                    body.AddForce(Vector3.right * speed);
                    break;
                case 3:
                    body.AddForce(Vector3.forward * speed);
                    break;
                case 4:
                    body.AddForce(Vector3.left * speed);
                    break;
            }
        }
        if(body.velocity.magnitude > maxVelocity)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }
    }
}
