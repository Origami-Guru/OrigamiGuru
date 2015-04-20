using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LoadCameraDetectorScene : MonoBehaviour { 

	public void LoadNextScene()
	{
		Application.LoadLevel("main_camdetect_scene");
	}
}
