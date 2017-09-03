using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour {
    public GameObject target; // 狙うオブジェクト
    public ScoreCounter GameController;
    SteamVR_TrackedObject trackedObj;
    public bool isShot; // 金魚すくいと射的の切り替え

    void Start()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        isShot = true;
    }

    // Update is called once per frame
    void Update () {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        //Transform camera = Camera.main.transform;
        if (isShot) // 射的モード
        {
            Ray ray;
            RaycastHit[] hits;
            GameObject hitObject;

            Debug.DrawRay(transform.position, transform.rotation * Vector3.forward * 100.0f);

            ray = new Ray(transform.position, transform.rotation * Vector3.forward);
            hits = Physics.RaycastAll(ray);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                hitObject = hit.collider.gameObject;
                if (hitObject.tag == "Mato")
                {
                    //Debug.Log("aim (x,y,z):" + hit.point.ToString("F2"));
                    if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
                    {
                        //Debug.Log("hit!");
                        device.TriggerHapticPulse(2000);
                        GameController.score++;
                        Debug.Log("score" + GameController.score);

                    }
                    //transform.position = hit.point;
                }
            }
        }
        else // 金魚すくいモード
        {
            // not implemented
            // まだ挙動を試してない
            // OnTriggerEnterを呼ぶことに対応させれば実装の必要なし？
        }
	}

    //void OnTriggerEnter(Collision col)
    //{
    //    if (isShot == false && col.gameObject == target) {
    //        Destroy(target);
    //        //device.TriggerHapticPulse(3000);
    //        GameController.score++;
    //        Debug.Log("score" + GameController.score);
    //    }
    //}

    void OnTriggerEnter(Collider col)
    {
        if (isShot == false && col.gameObject == target) {
            Destroy(target);
            //device.TriggerHapticPulse(3000);
            GameController.score++;
            Debug.Log("score" + GameController.score);
        }
    }
}
