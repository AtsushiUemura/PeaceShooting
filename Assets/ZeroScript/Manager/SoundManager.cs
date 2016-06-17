using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {

    public static SoundManager instance;

    [SerializeField]
    private AudioSource bgmSource;
    [SerializeField]
    private AudioSource seSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySe(AudioClip se)
    {
        seSource.clip = se;
        seSource.Play();
    }

    public void PlayBgm(AudioClip bgm)
    {
        bgmSource.clip = bgm;
        bgmSource.Play();
    }

}
