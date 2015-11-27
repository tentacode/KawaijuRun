using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayRandomAudio : MonoBehaviour
{
    public List<AudioClip> sounds;

	void Start ()
    {
        AudioClip sound = sounds[Random.Range(0, sounds.Count)];
        AudioSource source = GetComponent<AudioSource>();
        source.clip = sound;
        source.Play();
	}
}
