using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DiscordPresence;

public class line : MonoBehaviour {
	
	
	public GameObject dline,tail,mcamera,road,decorates,dieeff;

	private GameObject tempgo,tempdia,tempcr;

	public bool direction,alive,start,load,roadmaker;

	public float cameraspeed,temprm;

	public Vector3 offset,tempcrgo;

	private GameObject[] dia,cr;

	List<GameObject> go =new List<GameObject>();

	void Start () 
	{
		start = start;
		load = true;
		alive = true;
		//find diamonds and crowns
		dia = GameObject.FindGameObjectsWithTag ("dia");
		cr = GameObject.FindGameObjectsWithTag ("crown");
		//
	}

	void Update () 
	{
		if (load == true) 
		{
			//save the initial distance between camera and line
			offset = mcamera.transform.position - dline.transform.position;
			cameraspeed = 0.03f;
			load = false;
			//
		}
		//restart
		if(Input.GetKeyDown(KeyCode.R)==true){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		//
		if (start == false && alive == true) 
		{//start game
			if (Input.GetMouseButtonDown(0) == true || Input.GetKeyDown (KeyCode.Space) == true) 
			{
				start = true;
				dline.GetComponent<AudioSource> ().enabled = true;
			}

		}//

		if (start == true) 
		{//turn
			if (Input.GetMouseButtonDown (0) == true || Input.GetKeyDown (KeyCode.Space) == true || Input.GetKeyDown(KeyCode.D) == true || Input.GetKeyDown(KeyCode.J) == true ) 
			{
				if (direction == true) 
				{
					direction = false;
				} 
				else 
				{
					direction = true;
				}
			}
		}//
		//build road/wall more efficiently
		if (roadmaker) 
		{
			temprm += 1;
			if (temprm % 6 == 1 || Input.GetMouseButtonDown(0) == true || Input.GetKeyDown (KeyCode.Space) == true) 
			{
				GameObject.Instantiate (road, dline.transform.position + new Vector3 (3, 0, -3), dline.transform.rotation);
				GameObject.Instantiate (road, dline.transform.position + new Vector3 (-3, 0, 3), dline.transform.rotation);
			}// // //
		} 
		else 
		{//when you play ...I dont put the part in Update but if(roadmaker) because these actions will create new gameobject and interfere the copying of road
			GameObject.Instantiate (tail, dline.transform.position, dline.transform.rotation);
			if (Input.GetMouseButtonDown (0) == true || Input.GetKeyDown (KeyCode.Space) == true ) 
			{
				if (direction == true) 
				{
					go.Add(GameObject.Instantiate (decorates, dline.transform.position + new Vector3 (8, -9, -5), dline.transform.rotation));
				} 
				else 
				{
					go.Add(GameObject.Instantiate (decorates, dline.transform.position + new Vector3 (-5, -9, 8), dline.transform.rotation));
				}
			}
		}//
	}

	void FixedUpdate () 
	{//smooth camera
		mcamera.transform.position = Vector3.Lerp (mcamera.transform.position, offset + dline.transform.position, cameraspeed);
	
		foreach (GameObject tempgo in go)
		{
			tempgo.transform.position += new Vector3 (0, 0.2f, 0);
		}

		foreach (GameObject tempdia in dia)
		{
			tempdia.transform.localEulerAngles += new Vector3 (0, 2, 0);
			if (Mathf.Abs (dline.transform.position.x - tempdia.transform.position.x) < 1 && Mathf.Abs (dline.transform.position.z - tempdia.transform.position.z) < 1 && tempdia.transform.localScale.z >0) 
			{
				tempdia.transform.localScale -= new Vector3 (0.3f, 0.3f, 0.3f);
			}
		}
		foreach (GameObject tempcr in cr)
		{
			tempcr.transform.localEulerAngles += new Vector3 (0, 2, 0);
			if (Mathf.Abs (dline.transform.position.x - tempcr.transform.position.x) < 2 && Mathf.Abs (dline.transform.position.z - tempcr.transform.position.z) < 2 && tempcr.transform.localScale.z >0) 
			{
				tempcr.transform.localScale -= new Vector3 (0.26f, 0.26f, 0.26f);
				tempcrgo = tempcr.transform.position;
			}
			if (tempcr.transform.localScale.z <=0) 
			{
				tempcrgo += new Vector3 (Random.Range (-2f, 2f), Random.Range (-1f, 2f), Random.Range (-2f, 2f));
				tempcr.GetComponent<Light> ().enabled = true;
				tempcr.transform.position = Vector3.Lerp (tempcr.transform.position, tempcrgo, 0.02f);

			}
		}
		//
		if (start == true && alive == true) 
		{//how the line move
			if (direction == true) 
			{
				dline.transform.position += new Vector3 (0.3f,0,0);
			}
			else
			{
				dline.transform.position += new Vector3 (0,0,0.3f);
			}
		}//
	}

	void OnCollisionEnter (Collision x) 
	{//when die...
		if (x.collider.tag == "wall") 
		{
			alive = false;
			mcamera.GetComponent<AudioSource> ().enabled = true;
			dieeff.SetActive (true);
		}// 
		//when complete the level...
		if (x.collider.tag == "Finish") 
		{
			offset = offset + offset + offset + offset;
			cameraspeed = 0.01f;
		}//
	}
}
