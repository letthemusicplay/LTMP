using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {
	
	// Variables
	ArrayList sections = new ArrayList();
	ArrayList colliders = new ArrayList();
	private bool isCheckToDelete = false;
//	private int activeSoundCount = 1;
//	float myTimer = 0.5f;
//	float timerVisible = 0.1f;
	
	// Use this for initialization
	void Start () {	
		// Create the road		
		for(int i = 0; i < 2; i++)
		{
			// Asset loading version
			//GameObject section = (GameObject)Instantiate(Resources.Load("section1"));
			
			// Get Avatar collider
			BoxCollider avatar = gameObject.GetComponent<BoxCollider>();
						
			// Prefab loading version
			GameObject section = Instantiate(Resources.Load("section")) as GameObject;
						
			section.transform.position = new Vector3(3.5f,-1.5f,80 * (i + 1));
			section.name = (i + 1).ToString();
			sections.Add(section);
			
			// Collision cube that trigger movement of the road
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = new Vector3(avatar.transform.position.x, avatar.transform.position.y,section.transform.position.z - 70);
			cube.AddComponent<Rigidbody>();
			cube.rigidbody.isKinematic = true;
			cube.renderer.enabled = false; // Objet invisible
			cube.name = (i + 1).ToString();
			cube.tag = "Road";
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
//		if (Input.GetKeyDown("space"))
//		{
//			if(activeSoundCount < nbTracks)
//			{
//				activeSoundCount++;
//				ActivateSound(activeSoundCount);
//			}
//		}
	}
	
	/// <summary>
	/// Moves the road.
	/// </summary>
	void MoveRoad()
	{
		for(int i = 0; i < sections.Count; i++)
		{
			GameObject section = sections[i] as GameObject;
			float newPos = section.transform.position.z - 0.35f;
			section.transform.position = new Vector3(section.transform.position.x,section.transform.position.y,newPos);
			
			GameObject cube = colliders[i] as GameObject;
			newPos = cube.transform.position.z - 0.35f;
			cube.transform.position = new Vector3(cube.transform.position.x,cube.transform.position.y,newPos);
		}
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
			GameObject section1 = sections[0] as GameObject;
			GameObject section2 = sections[1] as GameObject;
			GameObject cube1 = colliders[0] as GameObject;
			GameObject cube2 = colliders[1] as GameObject;
			switch(int.Parse(collider.name) - 1)
			{
				case 0 : section2.transform.position = new Vector3(section1.transform.position.x,section1.transform.position.y,section1.transform.position.z + (80));
					cube2.transform.position = new Vector3(cube1.transform.position.x,cube1.transform.position.y,cube1.transform.position.z + (80));
					break;
				case 1 : section1.transform.position = new Vector3(section2.transform.position.x,section2.transform.position.y,section2.transform.position.z + (80));
					cube1.transform.position = new Vector3(cube2.transform.position.x,cube2.transform.position.y,cube2.transform.position.z + (80));
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
