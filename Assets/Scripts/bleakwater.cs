using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bleakwater : MonoBehaviour {

    public GameObject Particle;

    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("bullet"))
        {
            GameObject expl = Instantiate(this.Particle, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(expl, 0.6f);
        }

    }

}