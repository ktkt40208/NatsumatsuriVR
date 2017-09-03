using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Rigidbody>().AddForce(0, 150, 0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
