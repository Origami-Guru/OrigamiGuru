using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;


public class GettingModels : MonoBehaviour {

	// create public property of singleton object
	public static GettingModels Instance {
		get
		{
			// allow user only get
			if (instance == null)
			{
				instance = GameObject.FindObjectOfType<GettingModels>();
			}
			return instance;
		}
	}

	public TextAsset stepJSON;
	public TextAsset modelJSON;
	public TextAsset modelStepJSON;

	//This is Singleton Object
	private static GettingModels instance;

	private void Awake() 
	{
		instance = this;
	}

	public Dictionary<string, string> getModel(string targetFoundName){
		var stepParsed = JSON.Parse(stepJSON.text);
		var modelParsed = JSON.Parse(modelJSON.text);
		var modelStepParsed = JSON.Parse(modelStepJSON.text);

		string stepNameOfSteps;
		int stepIDOfSteps = 0;
		int stepIdOfModelStep;
		int modelIdOfModelStep;
		int modelIdOfModel = 0;
		string modelNameOfModel;
		string modelSceneNameOfModel;

		int numOfSteps;
		int numOfModelSteps;
		int numOfModels;

		List<int> queryModels = new List<int>();
		Dictionary<string, string> ModelsDictionary = new Dictionary<string, string>();

		numOfSteps = stepParsed["steps"].Count;
		numOfModelSteps = modelStepParsed["models_steps"].Count;
		numOfModels = modelParsed["models"].Count;
		
		Debug.Log("Try to getting JSON Data");

		for(int i = 0; i < numOfSteps; i++){
			stepNameOfSteps = stepParsed["steps"][i]["step_name"];

			if(stepNameOfSteps.Equals(targetFoundName)){
				stepIDOfSteps = stepParsed["steps"][i]["step_id"].AsInt;
			}
		}

		if(stepIDOfSteps != 0){
			for(int i = 0; i < numOfModelSteps; i++){
				stepIdOfModelStep = modelStepParsed["models_steps"][i]["step_id"].AsInt;

				if(stepIdOfModelStep == stepIDOfSteps){
					modelIdOfModelStep = modelStepParsed["models_steps"][i]["model_id"].AsInt;
					queryModels.Add(modelIdOfModelStep);
				}
			}
		}

		if(queryModels.Count != 0){
			foreach(int queryModel in queryModels){
				for(int i = 0; i < numOfModels; i++){
					modelIdOfModel = modelParsed["models"][i]["model_id"].AsInt;

					if(queryModel == modelIdOfModel){
						modelNameOfModel = modelParsed["models"][i]["model_name"];
						modelSceneNameOfModel = modelParsed["models"][i]["model_scene_name"];
						if(!ModelsDictionary.ContainsKey(modelNameOfModel)){
							ModelsDictionary.Add(modelNameOfModel, modelSceneNameOfModel);
						}
					}
				}
			}
		}
		Debug.Log("model dictionary " + ModelsDictionary);
		return ModelsDictionary;
	}

	public bool getFinalStep(string currentSceneName, string targetFoundName){
		Debug.Log("trying to get final step");
		var stepParsed = JSON.Parse(stepJSON.text);
		var modelParsed = JSON.Parse(modelJSON.text);
		var modelStepParsed = JSON.Parse(modelStepJSON.text);

		string stepNameOfSteps;
		int stepIDOfSteps = 0;
		int stepIdOfModelStep;
		int modelIdOfModelStep;
		int modelIdOfModel = 0;
		string modelNameOfModel;
		string modelSceneNameOfModel;

		int numOfSteps;
		int numOfModelSteps;
		int numOfModels;

		bool isComplete = false;

		numOfSteps = stepParsed["steps"].Count;
		numOfModelSteps = modelStepParsed["models_steps"].Count;
		numOfModels = modelParsed["models"].Count;
		
		for(int i = 0; i < numOfSteps; i++){
			stepNameOfSteps = stepParsed["steps"][i]["step_name"];

			if(stepNameOfSteps.Equals(targetFoundName)){
				stepIDOfSteps = stepParsed["steps"][i]["step_id"].AsInt;
			}
		}

		for(int i = 0; i < numOfModels; i++){
			modelSceneNameOfModel = modelParsed["models"][i]["model_scene_name"];

			if(modelSceneNameOfModel.Equals(currentSceneName)){
				modelIdOfModel = modelParsed["models"][i]["model_id"].AsInt;
			}
		}

		if(stepIDOfSteps != 0 && modelIdOfModel != 0){
			for(int i = 0; i < numOfModelSteps; i++){
				stepIdOfModelStep = modelStepParsed["models_steps"][i]["step_id"].AsInt;
				modelIdOfModelStep = modelStepParsed["models_steps"][i]["model_id"].AsInt;

				if(stepIDOfSteps == stepIdOfModelStep && modelIdOfModel == modelIdOfModelStep){
					isComplete = modelStepParsed["models_steps"][i]["is_complete"].AsBool;
				}
			}
		}
		if(isComplete){
			Debug.Log("is final step");
		}	
		else{
			Debug.Log("is  not final step");

		}			
		return isComplete;
	}
}
