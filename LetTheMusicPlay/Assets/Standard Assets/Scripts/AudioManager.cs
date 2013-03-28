using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	public int nbTracks = 15;
	ArrayList audioSources = new ArrayList();
	private int activeSoundCount = 1;
	
	// Use this for initialization
	void Start () {
		for(int i = 0; i < nbTracks; i++)
		{
			AudioSource audio = (AudioSource) gameObject.AddComponent("AudioSource");
			audio.clip =  Resources.Load("Tracks/" + (i + 1).ToString()) as AudioClip;
			audio.loop = true;
			audio.mute = true;
			audio.Play();
			audioSources.Add(audio);
		}
		
		(audioSources[0] as AudioSource).mute = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
		{
			PlayLoop();
		}
	}
	
	// Play a new loop
	public void PlayLoop() {
		if(activeSoundCount < nbTracks)
		{
				activeSoundCount++;
				ActivateLoop(activeSoundCount);
		}
	}
	
	// Add a loop over the sound
	private void ActivateLoop(int soundNumber)
	{
		AudioSource audio = audioSources[soundNumber] as AudioSource;
		audio.mute = false;
	}
}
