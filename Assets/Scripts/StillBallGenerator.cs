using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StillBallGenerator : MonoBehaviour {

    public GameObject Ball1;
    public GameObject Ball2;
    public GameObject Ball3;
    public GameObject Ball4;
    public GameObject Ball0;
    public Transform player;
    float delta = 0;
    float span;

    float time = 0;

    // Use this for initialization
    void Start()
    {
        for (int i = 1; i <= 3; i++)
        {
            generate();
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        time += Time.deltaTime;
        if (time < 30)
        {
            span = 4f;
        }
        else if (time < 60)
        {
            span = 3f;
        }
        else
        { 
            span = 2f;
        }

        if (delta > span)
        {
            delta = 0;
            for (int i = 1; i <= 3; i++)
            {
                generate();
            }

        }
    }
    void generate()
    {
        float x = Random.Range(-4f, 5f);
        float y = Random.Range(1f, 8f);
        float z = Random.Range(8f, 12f);
        int color = Random.Range(0, 5);
        GameObject ball;
        if (color == 0)
        {
            ball = Instantiate(Ball0) as GameObject;
        }
        else if (color == 1)
        {
            ball = Instantiate(Ball1) as GameObject;
        }
        else if (color == 2)
        {
            ball = Instantiate(Ball2) as GameObject;
        }
        else if (color == 3)
        {
            ball = Instantiate(Ball3) as GameObject;
        }
        else
        {
            ball = Instantiate(Ball4) as GameObject;
        }
        ball.transform.position = new Vector3(x, y, z + player.position.z);
    }
}