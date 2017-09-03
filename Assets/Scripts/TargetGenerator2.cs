using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGenerator2 : MonoBehaviour {

    //public GameObject GameController;


    // オブジェクト生成時に初速度を与えて等速直線運動をさせる
    void Start()
    {
        GetComponent<Rigidbody>().velocity = - transform.forward;
    }

    // オブジェクトを(x, y, z)すべての成分をランダムにして回転運動をさせる
    void Update()
    {
        //transform.Rotate(new Vector3(Random.Range(0, 180),
        //                             Random.Range(0, 180),
        //                             Random.Range(0, 180)
        //                            ) * Time.deltaTime);
    }


    //コントローラー(Playerタグ付加)で触れると割れます(VIVEコントローラー側で処理することに決定）

    //    void OnCollisionEnter(Collision col)
    //    {
    //        if (col.gameObject.CompareTag("Player")) {
    //            Destroy(gameObject);
    //            GameObject.GetComponent<GameMaster>.score += 10;
    //            Debug.Log(score.ToString());
    //            Debug.Log("割った");
    //        }
    //    }
}