using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LoadCameraDetectorScene : MonoBehaviour { 

	public void LoadNextScene()
	{
		//Debug.Log("Helloworld");
		Application.LoadLevel("crane_scene");
	}
}
