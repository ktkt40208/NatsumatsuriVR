using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class TargetshooterAddPoint : MonoBehaviour {

    public GameObject GameController;
    public GameObject ScorePopUp;
    public GameObject ScorePopUpText;
    public GameObject AudioHit;
    public GameObject waterAudio;
    public GameObject firework;
    public SceneController sceneController;
    public GameObject Circle;
    public GameObject Batten;
    GameObject clone;


    int fireNum = 0;

    public GameObject Caption1;

    //private const string label = "The <#0050FF>count is: </color>{0:2}";

    //public TextMeshPro TextMeshProScore;


    // Use this for initialization
    void Start () {
        sceneController = GameObject.Find("GameController").GetComponent<SceneController>();
        if(sceneController == null)
        {
            Debug.Log("GameControllerが見つかりません");
        }
    }

    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("test");
        if (other.gameObject.CompareTag("Target")) {
            Destroy(other.gameObject);
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(AudioHit, hitPos, Quaternion.identity);
            Destroy(this.gameObject);

            if (SceneManager.GetActiveScene().name == "VRTK_VRflying") { // hogehogeシーンでのみやりたい処理
                GameController.GetComponent<GameMaster>().calcScore(10);
                //Debug.Log(GameController.GetComponent<GameMaster>().score);
                Debug.Log(GameController.GetComponent<GameMaster>().getScore().ToString());
                Debug.Log("当てた！");
                //ScorePopUpText.GetComponent<TMP_Text>().text = GameController.GetComponent<GameMaster>().score.ToString();
                //ScorePopUpText.GetComponent<TMP_Text>().text = GameController.GetComponent<GameMaster>().score.ToString();
                ScorePopUpText.GetComponent<TMP_Text>().text = "+10";

                //TextMeshProScore.SetText(label, score);

                Instantiate(ScorePopUp, hitPos, Quaternion.identity);

            }
            else { // それ以外のシーンでやりたい処理
                clone = (GameObject)Instantiate(Circle, hitPos, Quaternion.identity);
                clone.transform.LookAt(Camera.main.transform.position);
                GameController.GetComponent<GameMaster>().targethit = true;
            }




        }

        if (other.gameObject.CompareTag("Baloon")) {
            //bleakwaterクラスによりbulletタグによって破壊される
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(waterAudio, hitPos, Quaternion.identity);

            if (SceneManager.GetActiveScene().name == "VRTK_VRflying") { // hogehogeシーンでのみやりたい処理
                GameController.GetComponent<GameMaster>().calcScore(-20);
                //Debug.Log(GameController.GetComponent<GameMaster>().score);
                Debug.Log(GameController.GetComponent<GameMaster>().getScore().ToString());
                Debug.Log("銃で割ってしまった！");


                ScorePopUpText.GetComponent<TMP_Text>().text = "-20";

                Instantiate(ScorePopUp, hitPos, Quaternion.identity);

            }
            else { // それ以外のシーンでやりたい処理
                clone = (GameObject)Instantiate(Batten, hitPos, Quaternion.identity);
                clone.transform.LookAt(Camera.main.transform.position);
                GameController.GetComponent<GameMaster>().baloonhit = true;

            }

        }

        if (other.gameObject.CompareTag("button"))
        {
            Debug.Log("buttonにhit");
            sceneController.ChangeScene();


        }


        if (other.gameObject.CompareTag("startscene")) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Caption1.SetActive(true);

        }


        if (other.gameObject.CompareTag("HanabiTrigger"))
        {

            //Debug.Log("打ち上げ花火");

            Destroy(this.gameObject);
            Destroy(other.gameObject);

            //ScorePopUpText.GetComponent<TMP_Text>().text = "-10";

            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(firework, hitPos, Quaternion.Euler(-90,0,0));
            //Instantiate(waterAudio, hitPos, Quaternion.identity);

            //sceneController.ChangeScene();
        }

        if (other.gameObject.CompareTag("HanabiTrigger2"))
        {

            //Debug.Log("打ち上げ花火");

            Destroy(this.gameObject);
            Destroy(other.gameObject);


            //ScorePopUpText.GetComponent<TMP_Text>().text = "-10";

            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(firework, hitPos, Quaternion.Euler(-90,0,0));
            //Instantiate(waterAudio, hitPos, Quaternion.identity);

            //sceneController.ChangeScene();

        }

        if (other.gameObject.CompareTag("HanabiTrigger3")) {

            //Debug.Log("打ち上げ花火");

            Destroy(this.gameObject);
            Destroy(other.gameObject);


            //ScorePopUpText.GetComponent<TMP_Text>().text = "-10";

            Vector3 hitPos = other.ClosestPointOnBounds(this.transform.position);
            Instantiate(firework, hitPos, Quaternion.Euler(-90, 0, 0));
            //Instantiate(waterAudio, hitPos, Quaternion.identity);

            //スコアのリセット
            //GameController.GetComponent<GameMaster>().setScore(0);

            sceneController.ChangeScene();


        }
    }

    //void SceneMove()
    //{
    //    sceneController.ChangeScene();
    //}

}
