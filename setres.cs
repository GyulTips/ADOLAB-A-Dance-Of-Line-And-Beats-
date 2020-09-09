using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setres : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
        {
#pragma warning disable CS0618 // 형식 또는 멤버는 사용되지 않습니다.z
			Screen.SetResolution(1920, 1080, true);
			SceneManager.LoadScene(79);
			PlayerPrefs.DeleteAll();
			QualitySettings.SetQualityLevel(8, true);
            Debug.Log("Quality settings set to 'Default'");
#pragma warning restore CS0618 // 형식 또는 멤버는 사용되지 않습니다.
		}
	}

	 public void resetgame()
	 {
      	Screen.SetResolution(1920, 1080, true);
		SceneManager.LoadScene(79);
		PlayerPrefs.DeleteAll();
		QualitySettings.SetQualityLevel(8, true);
		Debug.Log("Quality settings set to 'Default'");
	 }

}
