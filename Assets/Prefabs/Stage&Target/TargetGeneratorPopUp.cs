using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGeneratorPopUp : MonoBehaviour {

    public GameObject targets;
    public Transform player;
    float delta = 0;
    float span;
    float which = 0; //左右どちらの屋台から飛んでくるか
    float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        this.time += Time.deltaTime;
        if (this.time < 5)
        {
            span = 2.0f;
        }else if(this.time<10){
            span = 1.0f;
        }else
        {
            span = 0.5f;
        }

        if (this.delta > this.span)
        {
            this.delta = 0;
            int x = Random.Range(0,4);
            float z =player.position.z + 10; //プレイヤーから少し離れた所に生成

            if (x == 0) //屋台の左右をランダムに設定
            {
                which = 4;
            } else if (x == 1) 
            {
                which = 3;
            } else if(x==2){
                which = -3;
            }
            else
            {
                which = -4;
            }
            GameObject target= Instantiate(targets) as GameObject;
            target.transform.position = new Vector3(which,0, z);
        }
	}
}
