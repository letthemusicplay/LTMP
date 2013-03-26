using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {
	
	// Variables
	ArrayList pistes = new ArrayList();
	ArrayList colliders = new ArrayList();
	ArrayList audioSources = new ArrayList();
	private bool isCheckToDelete = false;
	private int activeSoundCount = 1;
	public int nbTracks = 15;
//	float myTimer = 0.5f;
//	float timerVisible = 0.1f;
	
	// Use this for initialization
	void Start () {
		
		// Initialisation de la liste Audiosource
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
		
		// création de la route		
		for(int i = 1;i<3;i++)
		{
			GameObject piste = (GameObject)Instantiate(Resources.Load("piste1"));
			piste.transform.position = new Vector3(2.5f,-0.5f,165 * i);
			piste.name = i.ToString();
			//piste.layer = 9;
			pistes.Add(piste);
			
			// Cubes de collision pour déplacer la route
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = new Vector3(0,0,piste.transform.position.z - 150);
			cube.AddComponent<Rigidbody>();
			cube.rigidbody.isKinematic = true;
			cube.renderer.enabled = false; // Objet invisible
			cube.name = i.ToString();
			cube.tag = "Road";
			//cube.renderer.material.shader = Shader.Find("Custom/Transparent");
			colliders.Add(cube);
		}
	
		

//		for(int i = 0;i<10000;i++)
//		{
//			
//			
//			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//			GameObject cubeAudio = GameObject.CreatePrimitive(PrimitiveType.Cube);
//					    
//			cubeAudio.renderer.material = Resources.Load("fuelcellglowtexture", typeof(Material)) as Material;
//			cubeAudio.renderer.material.shader = Shader.Find("Transparent/Diffuse");
//								
//			switch(type)
//			{
//				case 1 : cubeAudio.renderer.material.color = Color.red; type = 2;
//					break;
//				case 2 : cubeAudio.renderer.material.color = Color.yellow; type = 3;
//					break;
//				case 3 : cubeAudio.renderer.material.color = Color.green; type = 1;
//					break;
//			}
//			cube.renderer.material.mainTexture = Resources.Load("RoadTexture") as Texture;
//			cube.name = i + "_" + type; // type de chaque cube composant la route (lié a chaque riff)
//			//type = type != maxType ? type++ : 1;
//			
//			cube.collider.enabled = true;
//			cube.collider.isTrigger = true; // On autorise les évènements sur les cubes
//			
//			cube.transform.position = new Vector3(0,-1,cubePosNb);
//			cube.transform.localScale=new Vector3(10,0.1f,10);
//			cubeAudio.transform.position = new Vector3(0,-1,cubePosNb);
//			cubeAudio.transform.localScale=new Vector3(10,0.1f,10);
//			cubes.Add(cubeAudio);
//			cubePosNb += 10;
//		}	
		
	}
	
	// Update is called once per frame
	void Update () {
		
		MoveRoad();
		
		CheckInput();
				
//		if(myTimer < 0)
//		{
//			analyseSounds(0.5f);
//			if(timerVisible < 0)
//			{
//				myTimer = 0.5f;
//				timerVisible = 0.1f;
//			}
//			else{
//				timerVisible -= Time.deltaTime;
//			}
//		}
//		else
//		{
//			analyseSounds(0);
//			myTimer -= Time.deltaTime;
//		}
	}
	
	/// <summary>
	/// Checks the input.
	/// </summary>
	void CheckInput()
	{
		if (Input.GetKeyDown("space"))
		{
			if(activeSoundCount < nbTracks)
			{
				activeSoundCount++;
				ActivateSound(activeSoundCount);
			}
		}
	}
	
	/// <summary>
	/// Moves the road.
	/// </summary>
	void MoveRoad()
	{
		for(int i = 0;i<pistes.Count;i++)
		{
			GameObject piste = pistes[i] as GameObject;
			float newPos = piste.transform.position.z - 0.1f;
			piste.transform.position = new Vector3(piste.transform.position.x,piste.transform.position.y,newPos);
			
			GameObject cube = colliders[i] as GameObject;
			newPos = cube.transform.position.z - 0.1f;
			cube.transform.position = new Vector3(cube.transform.position.x,cube.transform.position.y,newPos);
		}
	}
	
	/// <summary>
	/// Activates the sound.
	/// </summary>
	/// <param name='soundNumber'>
	/// Sound number.
	/// </param>
	void ActivateSound(int soundNumber)
	{
		AudioSource audio = audioSources[soundNumber-1] as AudioSource;
		audio.mute = false;
	}
	
	/// <summary>
	/// Roads process.
	/// </summary>
	/// <param name='collider'>
	/// Collider.
	/// </param>
	void RoadProcess(Collider collider)
	{
		if(isCheckToDelete)
		{
			GameObject piste1 = pistes[0] as GameObject;
			GameObject piste2 = pistes[1] as GameObject;
			GameObject cube1 = colliders[0] as GameObject;
			GameObject cube2 = colliders[1] as GameObject;
			switch(int.Parse(collider.name) - 1)
			{
				case 0 : piste2.transform.position = new Vector3(piste1.transform.position.x,piste1.transform.position.y,piste1.transform.position.z + (165));
					cube2.transform.position = new Vector3(cube1.transform.position.x,cube1.transform.position.y,cube1.transform.position.z + (165));
					break;
				case 1 : piste1.transform.position = new Vector3(piste2.transform.position.x,piste2.transform.position.y,piste2.transform.position.z + (165));
					cube1.transform.position = new Vector3(cube2.transform.position.x,cube2.transform.position.y,cube2.transform.position.z + (165));
					break;
			}			
		}
		isCheckToDelete = true;
	}
	
	// Gestion des évènements
	void OnTriggerEnter (Collider collider) {
		if(collider.tag=="Road")
		{
			RoadProcess(collider);
		}
	}

//	void OnTriggerStay (Collider collider) {
//		if(collider.tag=="Road")
//		{
//	
//		}
//	}
	
//	void analyseSounds(float h)
//	{
//		//audio.GetOutputData(samples,0);
//
//		for(int i = 0;i<numSamples;i++)
//		{
//			GameObject cube = cubes[i] as GameObject;
//			moveCubes(cube, h); //samples[i]
//		}
//	}
	
//	void moveCubes(GameObject _cube, float _sample)
//	{
//		if(_sample > -0)
//		{
//			_cube.transform.localScale=new Vector3(10,_sample,10);
//		}
//		else
//		{
//			_cube.transform.localScale=new Vector3(10,0.5f * _sample,10);
//		}
//	}
}
