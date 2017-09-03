using UnityEngine;
using System.Collections;

public class RandomObjectGenerator : MonoBehaviour {

    public GameObject targetGameObject;
    //public float MinRange, MaxRange;
    public float RangeX, RangeY, LengthZ;

    public int generatingNumber;

    // 今はとりあえず決め打ちで500個生成しています
    void Start()
    {
        for (int i = 0; i <= generatingNumber; i++) {
            Instantiate(targetGameObject, new Vector3(Random.Range(-RangeX, RangeX),
                  Random.Range(-RangeY, RangeY),
                  Random.Range(0, LengthZ)),
                  Quaternion.Euler(Random.Range(0, 10),
                                   Random.Range(180, 180),
                                   Random.Range(0, 10)));
        }
    }
}
