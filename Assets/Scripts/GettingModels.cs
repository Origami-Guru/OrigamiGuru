using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;


public class GettingModels : MonoBehaviour {
	public TextAsset stepJSON;
	public TextAsset modelJSON;
	public TextAsset modelStepJSON;
	public TextAsset twoDimensionStepJSON;

	void Start(){

	}

	public Dictionary<string, string> getModel(string targetFoundName){
		var stepParsed = JSON.Parse(stepJSON.text);
		var modelParsed = JSON.Parse(modelJSON.text);
		var modelStepParsed = JSON.Parse(modelStepJSON.text);

		string stepNameOfSteps;
		int stepIDOfSteps = 0;
		int stepIdOfModelStep;
		int modelIdOfModelStep;
		int modelIdOfModel;
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

						ModelsDictionary.Add(modelNameOfModel, modelSceneNameOfModel);
					}
				}
			}
		}

		return ModelsDictionary;
	}
}
