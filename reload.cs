using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.D))
        {
#pragma warning disable CS0618 // 형식 또는 멤버는 사용되지 않습니다.
			SceneManager.LoadScene(80);
#pragma warning restore CS0618 // 형식 또는 멤버는 사용되지 않습니다.
		}
	}
}
