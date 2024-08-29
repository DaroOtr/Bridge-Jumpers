using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameplayMusic;
    [SerializeField] private AudioClip creditsMusic;


    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    /// <summary>
    /// Function To PLay An One Shot Of a Audio Clip That you Give it By Parameterr
    /// </summary>
    /// <param name="clip"></param>
    public void PlaySound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    /// <summary>
    /// Function To Play An One Shot Of A Audio Clip at a certain volume That you Give it By Parameter
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="volume"></param>
    public void PlaySound(AudioClip clip, float volume)
    {
        effectSource.PlayOneShot(clip, volume);
    }

    /// <summary>
    /// Play A Music That you Give it By Parameter
    /// </summary>
    /// <param name="clip"></param>
    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    /// <summary>
    /// Stops The Current Music Audio Clip
    /// </summary>
    public void StopMusic()
    {
        musicSource.Stop();
    }

    /// <summary>
    /// Returns The Audio Source For The Music
    /// </summary>
    /// <returns></returns>
    public AudioSource GetMusicSource()
    {
        return musicSource;
    }
    
    public AudioSource GetEffectSource()
    {
        return effectSource;
    }

    /// <summary>
    /// Toggle The Music && SFX To Mute or UN Mute
    /// </summary>
    public void ToggleAudio()
    {
        effectSource.mute = !effectSource.mute;
        musicSource.mute = !musicSource.mute;
    }

    public void ChangeMusic_Volume(float volume) 
    {
        musicSource.volume = volume;
    }

    public void ChangeSFX_Volume(float volume) 
    {
        effectSource.volume = volume;
    }

    public void PlayMenuMusic()
    {
        musicSource.Stop();
        musicSource.clip = menuMusic;
        musicSource.Play();
    }
    
    public void PlayGameplayMusic()
    {
        musicSource.Stop();
        musicSource.clip = gameplayMusic;
        musicSource.Play();
    }
    
    public void PlayCreditsMusic()
    {
        musicSource.Stop();
        musicSource.clip = creditsMusic;
        musicSource.Play();
    }
}
