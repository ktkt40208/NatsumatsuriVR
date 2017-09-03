using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

    //スコア
    public static int score = 0;
    public float bodyweight = 0;
    public Text scoreText;
    public Text BodyWeightText;


    public bool targethit = false;
    public bool kingyohit = false;
    public bool baloonhit = false;

    public GameObject Caption2;

    // Use this for initialization
    void Start () {
        scoreText.text = "得点: 0";
        BodyWeightText.text = "BodyWeight: 0";

    }

    // Update is called once per frame
    void Update () {
        scoreText.text = "得点: " + score.ToString();
        BodyWeightText.text = "BodyWeight: " + bodyweight.ToString();

        if (targethit == true && kingyohit == true && baloonhit == true) {
            Caption2.SetActive(true);
        }


    }

    public int getScore()
    {
        return score;
    }

    public void calcScore(int num)
    {
        score += num;
    }

    public void setScore(int num)
    {
        score = num;
    }


}
