using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBallGenerator: MonoBehaviour {

    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Ball4;
    public GameObject Ball0;
    public Transform player;
    float delta = 0;
    float span;
    float which = 0; //左右どちらの屋台から飛んでくるか
    float time = 0;
    public int generationhight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        this.time += Time.deltaTime;
        if (this.time < 5)
        {
            span = 2f;
        }else if(this.time<10){
            span = 1f;
        }else
        {
            span = 0.5f;
        }

        if (this.delta > this.span)
        {
            this.delta = 0;
            float x = Random.Range(-4,5);
            float z =player.position.z + 15; //プレイヤーから少し離れた所に生成
            int color = Random.Range(0,5);
            GameObject ball;
            if (color == 0)
            {
                ball = Instantiate(Ball0) as GameObject;
            }else if (color == 1)
            {
                ball = Instantiate(Ball1) as GameObject;
            }else if (color == 2)
            {
                ball = Instantiate(Ball2) as GameObject;
            }else if (color == 3)
            {
                ball = Instantiate(Ball3) as GameObject;
            }else
            {
                ball = Instantiate(Ball4) as GameObject;
            }
            ball.transform.position = new Vector3(x, generationhight + player.position.y, z-6);

        }
	}
}
