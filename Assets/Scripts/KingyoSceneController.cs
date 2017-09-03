using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingyoSceneController : MonoBehaviour {
    public GameObject prefab;
    public GameObject MyBody;
    public float ObjectDistance = 10.0f; // ターゲット間の距離
    public float width = 30.0f; // ターゲット出現の幅の範囲を制御する
    public float height = 5.0f; // ターゲット出現の高さの範囲を制御する

	// Use this for initialization
	void Start () {
        Vector3 StartPosition = MyBody.transform.position;
		for(int i = 1; i <= 10; i++) // 初期状態では10個生成
        {
            Vector3 pos = new Vector3(Random.Range(-width,width),Random.Range(-height,height),StartPosition.z + i * ObjectDistance);
            Instantiate(prefab,pos, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
