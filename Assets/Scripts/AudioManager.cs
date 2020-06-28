using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;

    public AudioSource backgroundMusic;
    public AudioSource playerSFX;
    public AudioSource miscSFX;

    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(AudioManager).Name;
                    _instance = obj.AddComponent<AudioManager>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    public void PlayMainTheme()
    {
        backgroundMusic.clip = (AudioClip)Resources.Load("Audio/BG_Main_Theme");
        backgroundMusic.Play();
    }

    public void PlayMenuTheme()
    {
        backgroundMusic.clip = (AudioClip)Resources.Load("Audio/BG_Menu_Theme");
        backgroundMusic.Play();
    }

    public void PlayPlayerSFX(string audioFile)
    {
        playerSFX.clip = (AudioClip)Resources.Load("Audio/" + audioFile);
    }

    public void PlayMiscSFX(string audioFile)
    {
        miscSFX.clip = (AudioClip)Resources.Load("Audio/" + audioFile);
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayMenuTheme();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
