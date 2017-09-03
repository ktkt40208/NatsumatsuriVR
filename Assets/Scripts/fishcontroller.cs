using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishcontroller : MonoBehaviour {

    public float fishspeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 FishSpeed = new Vector3(0,0, fishspeed);
        transform.Translate(0, 0, fishspeed);
        gameObject.transform.position += FishSpeed;

    }
}
