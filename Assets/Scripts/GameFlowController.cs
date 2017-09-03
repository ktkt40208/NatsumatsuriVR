using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowController : MonoBehaviour {

    float delta;
    public float targetOnly;
    public float targetWithBaloon;
    public float kingyoWithBaloon;
    public float targetWithKingyoWithBaloon;
    public float targetWithKingyoWithBaloonWithBoundingBaloon;

    public GameObject leftGun;
    public GameObject leftKingyo;
    public GameObject rightGun;
    public GameObject rightKingyo;

    void Awake () {
        delta = 0;
    }
	
	// Update is called once per frame
	void Update () {
        delta += Time.deltaTime;
        if (delta > targetWithKingyoWithBaloonWithBoundingBaloon)
        {
            GetComponent<StillBallGenerator>().enabled = true;
            leftGun.SetActive(true);
            leftKingyo.SetActive(true);
            rightGun.SetActive(true);
            rightKingyo.SetActive(true);
        }
        else if (delta > targetWithKingyoWithBaloon) {
            GetComponent<TargetGenerator>().enabled = true;
            leftGun.SetActive(false);
            leftKingyo.SetActive(true);
            rightGun.SetActive(true);
            rightKingyo.SetActive(false);
        }
        else if (delta > kingyoWithBaloon)
        {
            GetComponent<KingyoGenerator>().enabled = true;
            GetComponent<TargetGenerator>().enabled = false;
            //GameObject.Find("Controller (right)").transform.Find("GoldenFishScraper").gameObject.SetActive(true);
            //GameObject.Find("Controller (left)").transform.Find("GoldenFishScraper").gameObject.SetActive(true);
            //GameObject.Find("Controller (right)").transform.Find("RealGun").gameObject.SetActive(false);
            //GameObject.Find("Controller (left)").transform.Find("RealGun").gameObject.SetActive(false);
            leftGun.SetActive(false);
            leftKingyo.SetActive(true);
            rightGun.SetActive(false);
            rightKingyo.SetActive(true);

        }
        else if (delta > targetWithBaloon) {
            GetComponent<WaterBallGenerator>().enabled = true;
        }
        else if (delta > targetOnly)
        {
            GetComponent<TargetGenerator>().enabled = true;
        }

    }
}
