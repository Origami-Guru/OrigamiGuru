using UnityEngine;
using System.Collections;

public class SplashTimeOut : MonoBehaviour {

	private double timeCount = 2.0;
	private bool isLogin = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(timeCount > 0){
			timeCount = timeCount - Time.deltaTime;
		}
		else{
			if(isLogin == true){
				Application.LoadLevel("main_menu_after_login");
			}
			else{
				//Application.LoadLevel("register_and_login");
			}
		}
	}
}
