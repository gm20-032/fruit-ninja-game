using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    static public SoundManager Instance { get; private set; } = null;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource musicSource;
    //[SerializeField] AudioMixer mixer;

    private float sfxVolume = 1.0f;         // for tracking sfx volume
    private float musicVolume = 1.0f;       // for tracking music volume

    const string PP_MUSIC_VOL = "MusicVol";     // PlayerPrefs key for saving music volume
    const string PP_SFX_VOL = "SfxVol";         // PlayerPrefs key for saving sound volume
    //[SerializeField] private AudioClip sliceSound;
    //[SerializeField] private AudioClip melonCutSound;
    //[SerializeField] private AudioClip explosionSound;

    // convert from linear to logarithmic scale (0.0-1.0 to decibels)
    private float LinearToLog(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    // a property to get/set sfx volume
    public float SfxVolume
    {
        get { return sfxVolume; }
        set
        {
            sfxVolume = Mathf.Clamp(value, 0.0f, 1.0f); // limit vol range
            //mixer.SetFloat("SfxVolume", LinearToLog(sfxVolume));     // set mixer sfx vol
        }
    }

    // a property to get/set music volume
    public float MusicVolume
    {
        get { return musicVolume; }
        set
        {
            musicVolume = Mathf.Clamp(value, 0.0f, 1.0f); // limit vol range
            //mixer.SetFloat("MusicVolume", LinearToLog(musicVolume));   // set mixer music vol
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        // Restore volume slider values [0...1] from PlayerPrefs
        MusicVolume = PlayerPrefs.GetFloat(PP_MUSIC_VOL, 1f);   // if not found, use 1
        SfxVolume = PlayerPrefs.GetFloat(PP_SFX_VOL, 1f);       // if not found, use 1
    }

    private void OnDestroy()
    {
        // Save volume slider values [0...1] to PlayerPrefs
        PlayerPrefs.SetFloat(PP_MUSIC_VOL, musicVolume);    // save
        PlayerPrefs.SetFloat(PP_SFX_VOL, sfxVolume);        // save
    }

    // Play a sfx clip (fire & forget)
    public void PlaySfx(AudioClip clip, float volume = 1.0f)
    {
        sfxSource.PlayOneShot(clip, volume);
    }

    // Play a music clip (capable of being stopped)
    public void PlayMusic(AudioClip clip, float volume = 1.0f)
    {
        musicSource.clip = clip;
        musicSource.volume = volume;
        musicSource.Play();
    }

    // Stop the music!
    public void StopMusic()
    {
        musicSource.Stop();
    }

}
