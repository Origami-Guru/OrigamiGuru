using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class MainMenuFB : MonoBehaviour {
	public GameObject UIFBLoggedIn;
	public GameObject UIFBNotLoggedIn;
	//public GameObject UIFBAvatar;
	public GameObject UIFBUserName;
	private Dictionary<string, string> profile = null;
	// Use this for initialization
	
	private void SetInit(){
		Debug.Log ("SetInit");
	
		if (FB.IsLoggedIn) {

			Debug.Log ("Already logged in");
			
		} else {
			DealWithFBMenu(true);
			//FBLogin();
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

	public void FBLogin(){
	            
		FB.Login ("publish_actions", LoginCallback);                                                        
		                                                                                                  
		   
	}
	void LoginCallback(FBResult result)                                                        
	{                                                                                          
		Debug.Log("LoginCallback");                                                          
		
		if (FB.IsLoggedIn) {                                                                                      
			Debug.Log ("FB login worked");
			Debug.Log(FB.UserId);
			Debug.Log(FB.AccessToken);
			DealWithFBMenu(true);
			//OnLoggedIn();   
		} else
			Debug.Log ("FB loing Fail");
			DealWithFBMenu(false);
	}                                                                                          
	void OnLoggedIn()                                                                          
	{                                                                                          
		Debug.Log("Logged in. ID: " + FB.UserId);                                            
	}  
	void DealWithFBMenu(bool IsLoggedIn){
		if(IsLoggedIn){
			UIFBLoggedIn.SetActive (false);
			UIFBNotLoggedIn.SetActive(true);

			//get profile picture code
			//FB.API(Util.GetPictureURL("me",128,128),Facebook.HttpMethod.GET,DealWithProfilePicture);
			FB.API("/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUsername);
			//get username code
		}
		else{
			UIFBLoggedIn.SetActive(true);
			UIFBNotLoggedIn.SetActive(false);
		}
	}  

	void DealWithUsername(FBResult result){
		if (result.Error !=null) {
			Debug.Log ("Problem with getting Username");
			//FB.API(Util.GetPictureURL("me",128,128),Facebook.HttpMethod.GET,DealWithProfilePicture);
			FB.API("/me?fields=id,first_name", Facebook.HttpMethod.GET, DealWithUsername);
			return;

		}
		profile = Util.DeserializeJSONProfile(result.Text); 
		Text Usermsg = UIFBUserName.GetComponent<Text> ();
		Usermsg.text = "Helle," + profile ["first_name"];
	}
	public void ShareWithFriends (){
			FB.Feed(
			linkCaption:"i'm OrigamiGuru",
			picture:"https://photos-3.dropbox.com/t/2/AABN8t808wJxFo6cDi6c8L73y6xmjcAf182FaDJmnrQVWQ/12/22580284/jpeg/32x32/1/1432915200/0/2/pigeon_step_07_16.jpg/CLyY4gogASACIAMgBCAFIAYgBygBKAI/BEWaH1EVplmAs2e-iVlCxmyrzOV9C82mSvk2N-RIN0k?size=1024x768&size_mode=2",
			link:"https://photos-3.dropbox.com/t/2/AABN8t808wJxFo6cDi6c8L73y6xmjcAf182FaDJmnrQVWQ/12/22580284/jpeg/32x32/1/1432915200/0/2/pigeon_step_07_16.jpg/CLyY4gogASACIAMgBCAFIAYgBygBKAI/BEWaH1EVplmAs2e-iVlCxmyrzOV9C82mSvk2N-RIN0k?size=1024x768&size_mode=2",
			linkName:"Test Application OrgamiGuRU ProJeCt",
			callback: LoginCallback
			);
		
		}
}
