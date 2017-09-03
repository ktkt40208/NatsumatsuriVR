using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour {

    public GameObject targets;
    public Transform player;
    float delta = 0;
    float span;
    float which = 0; //左右どちらの屋台から飛んでくるか
    float time = 0;

	// Use this for initialization
	void Start () {

        for (int i = 1; i <= 3; i++)
        {
            Generate();
        }
    }
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        this.time += Time.deltaTime;

   //音楽に合わせた制御
        if (this.time < 19)
        {
            span = 4f;
        }
        else if (this.time < 39)
        {
            span = 3.0f;
        }
        else if (this.time < 55)
        {
            span = 2f;
        }
        else if (this.time < 61)
        {
            span = 3.0f;
        }
        else if (this.time < 91)
        {
            span = 2f;
        }
        else if (this.time < 106)
        {
            span = 1.5f;
        }
        else if (this.time < 121)
        {
            span = 1f;
        }
        else if (this.time < 140)
        {
            span = 4f;
        }
        else if (this.time < 160)
        {
            span = 3.0f;
        }
        else if (this.time < 176)
        {
            span = 2f;
        }
        else if (this.time < 182)
        {
            span = 3.0f;
        }
        else if (this.time < 212)
        {
            span = 2f;
        }
        else if (this.time < 227)
        {
            span = 1.5f;
        }
        else
        {
            span = 1f;
        }

        if (this.delta > this.span)
        {
            this.delta = 0;
            for (int i = 1; i <= 2; i++)
            {
                Generate();
            }
        }
	}

    void Generate()
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
        target.transform.position = new Vector3(which, 2, z);
    }
}
