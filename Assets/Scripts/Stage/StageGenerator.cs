using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {

    public int StageTipSize ; //ステージの長さ

    int currentTipIndex;

    public Transform character;　//プレイヤー　これの位置を取ってステージ生成
    public GameObject[] stageTips;　//生成するステージチップ（prefabから引っ張ってきてください）
    public int startTipIndex;  
    public int preInstantiate; //一度に表示するステージチップの数
    public List<GameObject> generatedStageList = new List<GameObject>();

	// Use this for initialization
	void Start () {
        currentTipIndex = startTipIndex - 1;
        UpdateStage(preInstantiate);
	}
	
	// Update is called once per frame
	void Update () {
        int charaPositionIndex = (int)(character.position.z / StageTipSize);
        if (charaPositionIndex + preInstantiate > currentTipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        } 
	}


    void UpdateStage(int toTipIndex)
    {
        if (toTipIndex <= currentTipIndex) return;

        for (int i = currentTipIndex + 1; i <= toTipIndex; i++)
        {
            GameObject stageObject = GenerateStage(i);
            generatedStageList.Add(stageObject);
        }
        while (generatedStageList.Count > preInstantiate + 0) DestroyOldestStage();

        currentTipIndex = toTipIndex;
    }

    GameObject GenerateStage(int tipIndex)
    {
        int nextStageTip = Random.Range(0, stageTips.Length);
        GameObject stageObject = (GameObject)Instantiate(
            stageTips[nextStageTip],
            new Vector3(0, 0, tipIndex * StageTipSize),　//これはｚ軸方面に進む場合
            Quaternion.identity
            );

        return stageObject;

    }
    void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

//初めにプレイヤーの前後に二枚だけステージチップを置いておく
//StageGeneratorをGameObjectとして作成、そこにこのスクリプトをアタッチ
//Inspectorから以下の項目を設定

//StageTipSizeでステージチップの長さを設定
//Charactorにプレイヤーをおく
//StageTipsのsizeを１　element0に生成したいステージチップのprefabをおく
//StartTipIndexを１ PreInsantiateを３以上にする（ここにいれた枚数ステージチップが生成される）
//GeneratedStageListのSizeを２　element0にプレイヤーの後ろのステージチップ　element1に前のステージチップを置く

//ステージチップは生成したいオブジェクトを全て空ゲームオブジェクトに放り込んだもの
//このゲームオブジェクトのPivotが原点じゃないと、なんかずれます（調査中）