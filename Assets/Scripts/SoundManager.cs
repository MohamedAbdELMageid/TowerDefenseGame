using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] AudioSource sfxSource_;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider2;
    Dictionary<string, AudioClip> audioClip = new Dictionary<string,AudioClip>();
    // Start is called before the first frame update
    void Start()
    {
        AudioClip[] clips=Resources.LoadAll<AudioClip>("Audio") as AudioClip[];
        foreach (AudioClip clip in clips)
        {
            audioClip.Add(clip.name, clip);
        }
        LoadVolume();
        musicSlider.onValueChanged.AddListener(delegate { UpdateVolume(); });
        sfxSlider2.onValueChanged.AddListener(delegate { UpdateVolume(); });
    }
    public void PlaySfx(string name)
    {
        sfxSource.PlayOneShot(audioClip[name]);
    }
    public void UpdateVolume()
    {
        musicSource.volume = musicSlider.value;
        sfxSource.volume = sfxSlider2.value;
        sfxSource_.volume = sfxSlider2.value;
        PlayerPrefs.SetFloat("Sfx",sfxSlider2.value);
        PlayerPrefs.SetFloat("Music",musicSlider.value);
    }
    public void LoadVolume()
    {
        sfxSource.volume = PlayerPrefs.GetFloat("Sfx", 0.5f);
        sfxSource_.volume = PlayerPrefs.GetFloat("Sfx", 0.5f);
        musicSource.volume = PlayerPrefs.GetFloat("Music", 0.5f);
        musicSlider.value = musicSource.volume;
        sfxSlider2.value = sfxSource.volume;
    }
}
