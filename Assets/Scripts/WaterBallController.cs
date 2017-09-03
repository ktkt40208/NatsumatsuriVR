using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallController : MonoBehaviour {
    Vector3 gravity = new Vector3(0, -3, 0);
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("[CameraRig]");
        /*float x = Random.Range(10,20);
        float y = Random.Range(100,150);
        if (this.transform.position.x>0) {
            PopUp(new Vector3(-x, y, 0));
        }else
        {
            PopUp(new Vector3(x, y, 0));
        }*/
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(gravity);
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }else if (player.transform.position.z - 5 > transform.position.z)
        {
            Destroy(gameObject);
        }
	}

    void PopUp(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
}
