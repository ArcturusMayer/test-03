using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobDetectRotation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private Animator anim;

    private int rotation = 1;
    private int prevRotation = 1;

    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.z - transform.position.z < player.transform.position.x - transform.position.x && player.transform.position.z - transform.position.z < -(player.transform.position.x - transform.position.x))
        {
            prevRotation = rotation;
            rotation = 1;
        }
        else if(player.transform.position.z - transform.position.z < player.transform.position.x - transform.position.x && player.transform.position.z - transform.position.z > -(player.transform.position.x - transform.position.x))
        {
            prevRotation = rotation;
            rotation = 2;
        }else if(player.transform.position.z - transform.position.z > player.transform.position.x - transform.position.x && player.transform.position.z - transform.position.z > -(player.transform.position.x - transform.position.x))
        {
            prevRotation = rotation;
            rotation = 3;
        }else if(player.transform.position.z - transform.position.z > player.transform.position.x - transform.position.x && player.transform.position.z - transform.position.z < -(player.transform.position.x - transform.position.x))
        {
            prevRotation = rotation;
            rotation = 4;
        }
        if (prevRotation != rotation)
        {
            anim.SetInteger("rotation", rotation);
        }
    }
}
