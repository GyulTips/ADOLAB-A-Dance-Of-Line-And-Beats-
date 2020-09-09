using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadfinish : MonoBehaviour 
 {
 public float delay = 7;
 public string NewLevel= "0";
  void Start()
 {
     StartCoroutine(LoadLevelAfterDelay(delay));     
 }
 
 IEnumerator LoadLevelAfterDelay(float delay)
 {
  yield return new WaitForSeconds(delay);
  SceneManager.LoadScene(NewLevel);
 }

 }