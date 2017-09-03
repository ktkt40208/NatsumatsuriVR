using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillBallController : MonoBehaviour {
    //GameObject player;
    Rigidbody ball;

    // Use this for initialization
    void Start()
    {
        //player = GameObject.Find("[CameraRig]");
    }

    // Update is called once per frame
    void Update()
    {
        ball = GetComponent<Rigidbody>();
        if (ball.transform.position.y < 0)
        {
            Destroy(gameObject);
        }

    }
}
