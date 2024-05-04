using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
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
    }
    public void PlaySfx(string name)
    {
        sfxSource.PlayOneShot(audioClip[name]);
    }
}
