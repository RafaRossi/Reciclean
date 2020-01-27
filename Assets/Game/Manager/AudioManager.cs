using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : Manager<AudioManager>
{
    //public List<AudioClip> hits = new List<AudioClip>();
    //public AudioClip hitsEffect;
    //public List<AudioClip> misses = new List<AudioClip>();
    //public AudioClip errorEffect;

    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource effectsAudioSource;
    [SerializeField] Settings settings;

    private bool PlayingMusic
    {
        get => settings.playMusic.Value;
        set => settings.playMusic.Value = value;
    }
    private bool PlayingEffects
    {
        get => settings.playSounds.Value;
        set => settings.playSounds.Value = value;
    }

    private void Start()
    {
        musicAudioSource.enabled = PlayingMusic;

        effectsAudioSource.enabled = PlayingEffects;
    }

    public void ToggleMusic()
    {
        musicAudioSource.enabled = PlayingMusic = !PlayingMusic;

        settings.playMusic.OnValueChanged();
    }

    public void ToggleEffects()
    {
        effectsAudioSource.enabled = PlayingEffects = !PlayingEffects;
        
        settings.playSounds.OnValueChanged();
    }

    public void PlayEffect(AudioClip effect)
    {
        if(effectsAudioSource.enabled)
            effectsAudioSource.PlayOneShot(effect);
    }
}
