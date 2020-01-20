using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource effectsAudioSource;

    public Image musicIcon;
    public Image effectsIcon;

    public Sprite musicIconOn;
    public Sprite musicIconOff;

    public Sprite effectsIconOn;
    public Sprite effectsIconOff;

    private bool playingMusic;
    private bool playingEffects;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playingMusic = PlayerPrefs.GetInt("Music") == 1 ? true : false;
        playingEffects = PlayerPrefs.GetInt("Effects") == 1 ? true : false;

        CheckMusicIcon(playingMusic);
        CheckEffectsIcon(playingEffects);

        if (playingMusic)
        {
            musicAudioSource.Play();
        }

        if (playingEffects)
        {
            effectsAudioSource.volume = 1;
        }
        else
        {
            effectsAudioSource.volume = 0;
        }
    }

    public void ToggleMusic()
    {
        playingMusic = !playingMusic;

        if (playingMusic)
        {
            musicAudioSource.Play();
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            musicAudioSource.Stop();
            PlayerPrefs.SetInt("Music", 0);
        }

        CheckMusicIcon(playingMusic);
    }

    public void ToggleEffects()
    {
        playingEffects = !playingEffects;

        if (playingEffects)
        {
            PlayerPrefs.SetInt("Effects", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Effects", 0);
        }

        effectsAudioSource.volume = PlayerPrefs.GetInt("Effects");
        CheckEffectsIcon(playingEffects);
    }

    void CheckMusicIcon(bool isOn)
    {
        if(musicIcon != null)
            musicIcon.sprite = isOn ? musicIconOn : musicIconOff;
    }

    void CheckEffectsIcon(bool isOn)
    {
        if(effectsIcon != null)
            effectsIcon.sprite = isOn ? effectsIconOn : effectsIconOff;
    }

    public void PlayEffect(AudioClip effect)
    {
        effectsAudioSource.PlayOneShot(effect);
    }
}
