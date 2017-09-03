﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;


public class WaterBallHitAddScore : MonoBehaviour {

    public GameObject GameController;
    public GameObject ScorePopUp;

    AudioSource HitAudio;                           // Reference to the audio source.  

    GameObject childObject;


    // Use this for initialization
    void Start () {
        GameController = GameObject.Find("GameController");

        HitAudio = GetComponent<AudioSource>();

        //parentObject(GameObject)の子要素(GameObject)取得
        childObject = transform.Find("waterEffect").gameObject;

    }

    // Update is called once per frame
    //   void Update () {

    //}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test");
        if (other.gameObject.CompareTag("Baloon")) {
            Destroy(other.gameObject);
            GameController.GetComponent<GameMaster>().calcScore(10);
            Debug.Log(GameController.GetComponent<GameMaster>().getScore());
            Debug.Log(GameController.GetComponent<GameMaster>().getScore().ToString());
            Debug.Log("割ってしまった！");

            HitAudio.Play();

            //Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            //Instantiate(ScorePopUp, hitPos, Quaternion.identity);

            //水のエフェクトをオン
            childObject.SetActive(true);
            Invoke("DelayMethod", 1.0f);


        }
    }

    void DelayMethod()
    {
        childObject.SetActive(false);

    }
}
