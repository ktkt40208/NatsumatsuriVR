using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingyoGenerator : MonoBehaviour {

    public GameObject targets;
    public Transform player;
    float delta = 0;
    float span;
    float which = 0; //左右どちらの屋台から飛んでくるか
    float time = 0;

	// Use this for initialization
	void Start () {
      
        generate();
        
    }
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        this.time += Time.deltaTime;

    //音楽に合わせた制御
        if (this.time < 6)
        {
            span = 3f;
        }
        else if (this.time < 36)
        {
            span = 2.0f;
        }
        else if (this.time < 51)
        {
            span = 1.5f;
        }
        else if (this.time < 66)
        {
            span = 1.0f;
        }
        else if (this.time < 85)
        {
            span = 4f;
        }
        else if (this.time < 105)
        {
            span = 3f;
        }
        else if (this.time < 121)
        {
            span = 2f;
        }
        else if (this.time < 127)
        {
            span = 3f;
        }
        else if (this.time < 157)
        {
            span = 2.0f;
        }
        else if (this.time < 172)
        {
            span = 1.5f;
        }
        else
        {
            span = 1.0f;
        }
        

        if (this.delta > this.span)
        {
            this.delta = 0;
            
            generate();
            
        }
            
	}

    void generate()
    {
            int x = Random.Range(0, 4);
            float z = player.position.z + 10; //プレイヤーから少し離れた所に生成

            if (x == 0) //屋台の左右をランダムに設定
            {
                which = 4;
            }
            else if (x == 1)
            {
                which = 3;
            }
            else if (x == 2)
            {
                which = -3;
            }
            else
            {
                which = -4;
            }
            GameObject target = Instantiate(targets) as GameObject;
            target.transform.position = new Vector3(which, 1, z);
        
    }
}
