using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RandomAudio : MonoBehaviour {

	[SerializeField]
	private AudioSource source;

	[SerializeField] private List<AudioClip> randomSounds;

	[SerializeField] private bool loopAudio = false;

	// Use this for initialization
	void Start () {
		if(source == null) {
			source = GetComponent<AudioSource>();
		}
		source.clip = RandomSound();
	}
	
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying && loopAudio) {
			source.clip = RandomSound();
			source.Play();
		}
	}

	private AudioClip RandomSound() {
		return randomSounds[Random.Range(0, randomSounds.Count)];
	}
}
