using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetControlle2 : MonoBehaviour {
    Vector3 gravity = new Vector3(0, -12, 0);
    

    // Use this for initialization
    void Start () {
        float x = Random.Range(60, 100);
        float y = Random.Range(500, 550);
        if (this.transform.position.x>0) {
            PopUp(new Vector3(-x, y, 0));
        }else
        {
            PopUp(new Vector3(x, y, 0));
        }
    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().AddForce(gravity);
        if (transform.position.y < 0.5f)
        {
            Destroy(gameObject);
        }
	}

    void PopUp(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }
}
