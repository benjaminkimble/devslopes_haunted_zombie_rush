using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BackgroundMusicController : MonoBehaviour {
	[SerializeField] private AudioClip menuMusic;
	[SerializeField] private AudioClip gameMusic;

	private AudioSource audioSource;

	private void Awake() {
		audioSource = GetComponent<AudioSource>();
		Assert.IsNotNull(menuMusic);
		Assert.IsNotNull(gameMusic);
		Assert.IsNotNull(audioSource);
	}

	private void Start () {
	}
	
	private void Update () {
		var clipToPlay = GameManager.Instance.GameStarted ?
			gameMusic : menuMusic;
		PlayMusic(clipToPlay);
	}

	private void PlayMusic(AudioClip clipToPlay) {
		if (audioSource.clip != clipToPlay) {
			audioSource.clip = clipToPlay;
			audioSource.Play();
		}
	}
}
