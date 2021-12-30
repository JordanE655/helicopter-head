using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound sound in sounds) {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
        }
    }

    public void Start()
    {
        HelicopterEvents.instance.myFirstAction += BoostSFX;
    }

    public void Play(string name)
    {
        foreach (Sound sound in sounds)
        {
            if (name == sound.name)
            {
                sound.audioSource.Play();
            }
        }
    }

    public void BoostSFX()
    {
        Play("full lift");
    }
}
