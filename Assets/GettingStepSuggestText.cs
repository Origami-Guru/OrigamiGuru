using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SimpleJSON;


public class GettingStepSuggestText : MonoBehaviour {

	public string catSuggestText(string targetFoundName){
		string suggestText = "";

			switch(targetFoundName){
				case "crane_step_00": {
					suggestText = "พับกระดาษตามรอยประ";
					break;
				}

				default: {
					suggestText = "คำแนะนำในการหันกระดาษที่มีลายเข้าหากล้อง";
					break;
				}
			}
		
		return suggestText;
	}


}
