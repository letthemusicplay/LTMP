using UnityEngine;
using System.Collections;

public class KinectInteract : MonoBehaviour {
	public int nbTracks = 15;
	ArrayList audioSources = new ArrayList();
	private int activeSoundCount = 1;
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ParticleSystem>().Pause();
		
		for(int i = 1;i<nbTracks +1;i++)
		{
			AudioSource audio = (AudioSource)gameObject.AddComponent("AudioSource");
			audio.clip =  Resources.Load("Tracks/" + i.ToString()) as AudioClip;
			if(i != 1)
			{
				audio.mute = true;
			}
			audio.loop = true;
			audio.Play();
			audioSources.Add(audio);
		}		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
    void OnTriggerEnter(Collider other) {
        //Destroy(other.gameObject);
		gameObject.GetComponent<ParticleSystem>().Play();
		if(activeSoundCount < nbTracks)
		{
				activeSoundCount++;
				ActivateSound(activeSoundCount);
		}
    }
	
	void OnTriggerExit(Collider other) {
		gameObject.GetComponent<ParticleSystem>().Stop();
	}
	
	void ActivateSound(int soundNumber)
	{
		AudioSource audio = audioSources[soundNumber-1] as AudioSource;
		audio.mute = false;
	}

}
