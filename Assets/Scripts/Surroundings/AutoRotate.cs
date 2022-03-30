using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    // Start is called before the first frame update

    public float XAngle = 90.0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3((Camera.main.transform.position - transform.position).x, 0, (Camera.main.transform.position - transform.position).z);
        float angle;
        if (transform.position.x < Camera.main.transform.position.x) {
            angle = (Vector3.Angle(dir, Vector3.forward));
        }
        else {
            angle = -(Vector3.Angle(dir, Vector3.forward));
        }
        Quaternion rotat = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = Quaternion.Euler(XAngle, rotat.eulerAngles.y, transform.rotation.z);
    }
}
