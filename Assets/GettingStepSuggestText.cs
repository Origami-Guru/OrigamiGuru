using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;


public class GettingStepSuggestText : MonoBehaviour {
	public TextAsset stepJSON;
	public TextAsset modelStepJSON;

	private int modelIDFromScene;
	private string suggestText;

	private void Start(){

	}

	public string getSuggestText(int modelID, string targetFoundName){
		var stepParsed = JSON.Parse(stepJSON.text);
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

		numOfSteps = stepParsed["steps"].Count;
		numOfModelSteps = modelStepParsed["models_steps"].Count;
		
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
				modelIdOfModelStep = modelStepParsed["models_steps"][i]["model_id"].AsInt;
				if((stepIdOfModelStep == stepIDOfSteps) && (modelIdOfModelStep == modelID)){
					suggestText = modelStepParsed["models_steps"][i]["description"];

				}
			}
		}

		return suggestText;
	}
}
