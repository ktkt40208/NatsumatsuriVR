using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class KingyoHitAddScore : MonoBehaviour {

    public GameObject GameController;
    public GameObject ScorePopUp;
    public GameObject ScorePopUpText;
    public GameObject Circle;
    GameObject clone;




    AudioSource HitAudio;                           // Reference to the audio source.  

    // Use this for initialization

    void Start()
    {
        GameController = GameObject.Find("GameController");
        HitAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame

    // void Update()
    // {

    // }

    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.CompareTag("Kingyo")) {
    //        Destroy(other.gameObject);
    //        GameController.GetComponent<GameMaster>().score += 10;
    //        Debug.Log(GameController.GetComponent<GameMaster>().score);
    //        Debug.Log(GameController.GetComponent<GameMaster>().score.ToString());
    //        Debug.Log("捕まえた");


    //    }
    //}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test");
        if (other.gameObject.CompareTag("Kingyo")) {
            Destroy(other.gameObject);
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            HitAudio.Play();

            if (SceneManager.GetActiveScene().name == "VRTK_VRflying") { // hogehogeシーンでのみやりたい処理
                GameController.GetComponent<GameMaster>().calcScore(20);
                Debug.Log(GameController.GetComponent<GameMaster>().getScore());
                Debug.Log(GameController.GetComponent<GameMaster>().getScore().ToString());
                Debug.Log("捕まえた");


                //ScorePopUpText.GetComponent<TMP_Text>().text = GameController.GetComponent<GameMaster>().score.ToString();
                ScorePopUpText.GetComponent<TMP_Text>().text = "+20";
                Instantiate(ScorePopUp, hitPos, Quaternion.identity);

            }
            else { // それ以外のシーンでやりたい処理
                clone = (GameObject)Instantiate(Circle, hitPos, Quaternion.identity);
                clone.transform.LookAt(Camera.main.transform.position);
                GameController.GetComponent<GameMaster>().kingyohit = true;

            }



        }

        //if (other.gameObject.CompareTag("Baloon")) {
        //    Destroy(other.gameObject);
        //    GameController.GetComponent<GameMaster>().score -= 10;
        //    Debug.Log(GameController.GetComponent<GameMaster>().score.ToString());
        //    Debug.Log("当たってしまった");
        //}


    }
}
