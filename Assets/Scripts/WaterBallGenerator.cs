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
    float time = 0;
    public int generationhight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        time += Time.deltaTime;
        if (time < 5)
        {
            span = 2f;
        }else if(time<10){
            span = 1f;
        }else
        {
            span = 0.5f;
        }

        if (delta > span)
        {
            delta = 0;
            float x = Random.Range(-4,5);
            float z = Random.Range(6f, 9f); 
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
            ball.transform.position = new Vector3(x, generationhight + player.position.y, player.position.z + z);

        }
	}
}
