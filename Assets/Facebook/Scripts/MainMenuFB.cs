using UnityEngine;
using System.Collections;

public class MainMenuFB : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	private void SetInit(){
		Debug.Log ("SetInit");
		enabled = true;
		if (FB.IsLoggedIn) {
			Debug.Log ("Already logged in");

		} else {
			FBLogin();
		}
	}
	private void OnHideUnity(bool isGameShown){
		Debug.Log ("OnHideUntiy");
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}

	}
	void Awake(){
		// Initialize FB SDK              
		             
		FB.Init(SetInit, OnHideUnity);  
	}

	void FBLogin(){
	            
		FB.Login ("email,publish_actions , user_about_me,user_birthday", LoginCallback);                                                        
		                                                                                                          
		   
	}
	void LoginCallback(FBResult result)                                                        
	{                                                                                          
		Debug.Log("LoginCallback");                                                          
		
		if (FB.IsLoggedIn) {                                                                                      
			Debug.Log ("FB login worked");   
			OnLoggedIn();   
		} else
			Debug.Log ("FB loing Fail");
	}                                                                                          
	void OnLoggedIn()                                                                          
	{                                                                                          
		Debug.Log("Logged in. ID: " + FB.UserId);                                            
	}  
	       

}
