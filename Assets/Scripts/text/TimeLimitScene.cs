using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class TimeLimitScene : MonoBehaviour {

    public float life_time = 3.0f;
    float time = 0f;
    public SceneController sceneController;


    // Use this for initialization
    void Start()
    {
        sceneController = GameObject.Find("GameController").GetComponent<SceneController>();

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //print(time);
        if (time > life_time) {
            Destroy(gameObject);
            sceneController.ChangeScene();

        }
    }
}