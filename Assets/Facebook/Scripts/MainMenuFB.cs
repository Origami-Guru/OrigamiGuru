using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class MainMenuFB : MonoBehaviour {
	public GameObject UIFBLoggedIn;
	public GameObject UIFBNotLoggedIn;
	//public GameObject UIFBAvatar;
	public GameObject UIFBUserName;
	public Image buttonShare;
	public GameObject UIFBUserNames;
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
	            
		FB.Login ("email, publish_actions", LoginCallback);                                                                                                                                                             
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
			FB.API("/me?fields=id,first_name,last_name", Facebook.HttpMethod.GET, DealWithUsername);
			return;
		}
		
		profile = Util.DeserializeJSONProfile(result.Text); 
		Text Usermsg = UIFBUserName.GetComponent<Text> ();
		Usermsg.text = "Welcome, " + profile ["first_name"]  + "\n to the new exiting experience \n of an Origami" ;
	}

	public void ShareWithFriends (){
		TakeScreenshot();
			FB.Feed(
			linkCaption:"i'm OrigamiGuru",
			picture:"",
			link:"",
			linkName:"Test Application OrgamiGuRU ProJeCt",
			callback: LoginCallback
			);
		
	}

	public IEnumerator TakeScreenshot() 
	{
	    yield return new WaitForEndOfFrame();

	    var width = Screen.width;
	    var height = Screen.height;
	    var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
	    // Read screen contents into the texture
	    tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
	    tex.Apply();
	    byte[] screenshot = tex.EncodeToPNG();

	    var wwwForm = new WWWForm();
	    wwwForm.AddBinaryData("image", screenshot, "cat.png");

	    FB.API("me/photos", Facebook.HttpMethod.POST, LoginCallback, wwwForm);
	    Debug.Log("try to share photo to facebook");
	}
}
