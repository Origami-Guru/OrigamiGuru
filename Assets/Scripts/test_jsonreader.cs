using UnityEngine;
using System.Collections;
using SimpleJSON;


public class test_jsonreader : MonoBehaviour {
	public TextAsset stepJSON;

	void Start(){
		var N = JSON.Parse(stepJSON.text);
		//Debug.Log("Before Parse: \n" + stepJSON.text);
		//Debug.Log("After Parse: \n" + N);
	}
}
