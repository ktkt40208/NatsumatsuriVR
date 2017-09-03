using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingyoController : MonoBehaviour {

    Rigidbody kingyo;
    Vector3 gravity = new Vector3(0, -0.5f, 0);
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("[CameraRig]");
        float x = Random.Range(0,2f);
        float y = Random.Range(6f,8f);
        
        if (this.transform.position.x>0) {
            PopUp(new Vector3(-x, y, 0));
        }else
        {
            PopUp(new Vector3(x, y, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {

        kingyo = GetComponent<Rigidbody>();

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        else if(kingyo.velocity.y < 0.01f)
        {
            kingyo.velocity = new Vector3(0,0, 0);
        }else
        {
            kingyo.AddForce(gravity);
        }
	}

    void PopUp(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
}
