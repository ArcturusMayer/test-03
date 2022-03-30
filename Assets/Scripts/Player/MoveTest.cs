using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10.0f;
    public float maxVelocity = 10.0f;

    private Rigidbody body;
    private bool isJumpAllowed = true;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Camera.main.transform.forward.normalized.x, 0, Camera.main.transform.forward.normalized.z) * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Camera.main.transform.forward.normalized.x, 0, Camera.main.transform.forward.normalized.z) * -speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Camera.main.transform.right.normalized.x, 0, Camera.main.transform.right.normalized.z) * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(Camera.main.transform.right.normalized.x, 0, Camera.main.transform.right.normalized.z) * speed);
        }
        if (Input.GetKey(KeyCode.Space) && isJumpAllowed)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.Impulse);
            isJumpAllowed = false;
        }
        if (body.velocity.magnitude > maxVelocity)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumpAllowed = true;
        }
    }
}
