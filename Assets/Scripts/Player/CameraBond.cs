using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBond : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 cam;

    void Start()
    {
        cam = gameObject.GetComponentInChildren<Camera>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cam = new Vector3(transform.position.x, cam.y, transform.position.z);
    }
}
