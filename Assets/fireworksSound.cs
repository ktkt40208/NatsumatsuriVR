using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireworksSound : MonoBehaviour
{
    [SerializeField]
    private GameObject explodeAudioObj;
    private ParticleSystem seedPs;

    // Use this for initialization
    void Start()
    {
        seedPs = GetComponent<ParticleSystem>();
        StartCoroutine(ProgressCo());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private int getSubEmitterParticleNum()
    {
        int ptNum = 0;
        ParticleSystem[] psArr = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in psArr)
        {
            ptNum += ps.particleCount;
        }
        return ptNum;
    }

    IEnumerator ProgressCo()
    {
        // ひゅるるる待ち
        while (seedPs.particleCount == 0)
        {
            yield return null;
        }
        // ひゅるるるの間は音の位置を移動
        while (seedPs.particleCount > 0)
        {
            ParticleSystem.Particle[] pps = new ParticleSystem.Particle[seedPs.particleCount];
            explodeAudioObj.transform.localPosition = pps[0].position;
            yield return null;
        }
        // 爆発待ち
        while (getSubEmitterParticleNum() == 0)
        {
            yield return null;
        }
        // 爆発音
        explodeAudioObj.GetComponent<AudioSource>().pitch *= Random.Range(0.8f, 1.2f);
        explodeAudioObj.GetComponent<AudioSource>().Play();
        // 消滅待ち
        while (getSubEmitterParticleNum() > 0)
        {
            yield return null;
        }
        // 消滅
        Destroy(gameObject);
    }
}
