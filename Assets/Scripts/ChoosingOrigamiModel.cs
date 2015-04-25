using UnityEngine;

public class ChoosingOrigamiModel : MonoBehaviour
{
	#region PUBLIC_MEMBER_VARIABLES
	public GUIStyle customWindow;
	public GUIStyle customButton;

	#endregion //PUBLIC_MEMBER_VARIABLES

	#region CUSTOM_GUISTYLE_METHODS

	public void makewords(){
		Debug.Log("make words!!!");
	}

	public void modelContent(int windowID){
		Rect buttonRect = new Rect(10, 30, 80, 20);
		GUI.Button(buttonRect, "Crane", customButton);
	}

	public void OnGUI(){
		Rect windowRect = new Rect(20, 20, Screen.width, Screen.height);
		GUI.Window(1, windowRect, modelContent, "Please choose any origami model", customWindow);
	}



	#endregion
}