using UnityEngine;
using System.Collections;

public class KinectInteract : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<ParticleSystem>().Pause();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
    void OnTriggerEnter(Collider other) {
		gameObject.GetComponent<ParticleSystem>().Play();
		GameDataManager.audioManager.PlayLoop();
    }
	
	void OnTriggerExit(Collider other) {
		gameObject.GetComponent<ParticleSystem>().Stop();
	}
}
