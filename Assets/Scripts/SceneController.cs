using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* このクラスは，sceneの切り替え及びフェードインアウト，さらにscene間で共有するデータ（scoreとか）の保管をする 
 * 各sceneのGameControllerにアタッチして使う．このコンポーネントにはフェード用のUI.Imageをアタッチしておく．
 * FadeCanvasを各sceneのカメラの前に画面を覆うように置いて，アタッチしたUI.Image以外何も見えないようにする
 * 先にBuildSettingsでsceneをbuildに加えるのを忘れないこと
 */

public class SceneController : MonoBehaviour {
    public float gameTime = 180.0f;
    public Image fadeImage;
    public float fadeSpeed = 0.01f;
    public float fadeInterval = 0.5f;
    public bool fade = false;
    public GameMaster gameMaster;

    // scene間で共有する変数にはstaticをつける
    //public static int score = 0;

    private float countDown;
    private float fadeCount;

	// Use this for initialization
	void Start () {
        setAlpha(fadeImage, 0.0f);
        countDown = gameTime;
        //Debug.Log("SceneControllerのStartが呼ばれました");
        gameMaster = GameObject.Find("GameController").GetComponent<GameMaster>();
	}
	
	// Update is called once per frame
	void Update () {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index != 0 && index != SceneManager.sceneCountInBuildSettings - 1) // startとendでは時間経過でscene遷移を行わない（UI.Buttonでやる）
        {
            countDown -= Time.deltaTime;
            if (countDown < 0.0f)
            {
                ChangeScene();
                countDown = gameTime;
            }
        }

        // aキーを押すことでシーン遷移
        if (Input.GetKeyDown("a") || fade == true)
        {
            ChangeScene();
        }
	}

    public void ChangeScene()
    {
        StartCoroutine(TransScene(fadeImage,fadeInterval));
    }

    void setAlpha(Image image,float alpha)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
    }

    private IEnumerator TransScene(Image image,float interval)
    {
        fadeCount = 0.0f;
        while (true)
        {
            fadeCount += fadeSpeed;
            if (fadeCount > 1.0f)
            {
                fadeCount = 1.0f;
                break;
            }
            setAlpha(image, fadeCount);
            yield return 0;
        }

        //Debug.Log("FadeOut!");

        int i = SceneManager.GetActiveScene().buildIndex;
        if (i < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(i + 1); // 1つ次のsceneに移動
        }
        else
        {
            // ここにstart画面に戻る前にやりたい処理を書く
            //Debug.Log("scoreは" + score + "でした");
            gameMaster.setScore(0);

            SceneManager.LoadScene(0); // 最後のsceneから0番目のsceneに移動
        }

        // sceneが変わるため，fadeInはここに書いても呼ばれない（Start()の中に書いてもダメだったので何か見落としてそう）
        /*fadeCount = 1.0f;
        //Debug.Log("FadeIn");
        while (true)
        {
            fadeCount -= fadeSpeed;
            if (fadeCount < 0.0f)
            {
                fadeCount = 0.0f;
                break;
            }
            setAlpha(image, fadeCount);
            yield return 0;
        }

        Debug.Log("FadeIn!");*/
    }

    public void changeSceneWithNoFading()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(i + 1); // 1つ次のsceneに移動
        }
        else
        {
            // ここにstart画面に戻る前にやりたい処理を書く
            //Debug.Log("scoreは" + score + "でした");
            gameMaster.setScore(0);

            SceneManager.LoadScene(0); // 最後のsceneから0番目のsceneに移動
        }
    }
}
