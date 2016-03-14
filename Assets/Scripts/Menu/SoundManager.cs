using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public float SoundSetting;
	public Toggle SoundToggle;
		
	// Update is called once per frame
	void Update () {
		SoundSlider (SoundSetting);
	}

	public void SoundSlider(float volume) {
		AudioListener.volume = volume;

		SoundSetting = volume;

		//GetComponent<AudioSource> ().outputAudioMixerGroup;
	}

}
