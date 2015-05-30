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
					suggestText = "พับครึ่งกระดาษตามรอยประ";
					break;
				}

				case "cat_step_01_01":
				case "cat_step_01_02":
				case "cat_step_01_03":
				case "cat_step_01_04": {
					suggestText = "พับครึ่งกระดาษให้เกิดรอยพับ แล้วคลี่ออก";
					break;
				}

				case "cat_step_02_01":
				case "cat_step_02_02":
				case "cat_step_02_03":
				case "cat_step_02_04": {
					suggestText = "พับครึ่งกระดาษให้เกิดรอยพับ แล้วคลี่ออก";
					break;
				}

				case "cat_step_03_02":
				case "cat_step_03_03":
				case "cat_step_03_05":
				case "cat_step_03_07":
				case "cat_step_03_08":
				case "cat_step_03_11":
				case "cat_step_03_13":
				case "cat_step_03_15": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "cat_step_03_01":
				case "cat_step_03_04":
				case "cat_step_03_06":
				case "cat_step_03_09":
				case "cat_step_03_10":
				case "cat_step_03_12":
				case "cat_step_03_14":
				case "cat_step_03_16": {
					suggestText = "พับกระดาษขึ้นด้านบนตามมรอยประ";
					break;
				}


				case "cat_step_04_01":
				case "cat_step_04_03":
				case "cat_step_04_05":
				case "cat_step_04_07": {
					suggestText = "พับกระดาษลงตามมรอยประ";
					break;
				}

				case "cat_step_04_02":
				case "cat_step_04_04":
				case "cat_step_04_06":
				case "cat_step_04_08": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "cat_step_05_02":
				case "cat_step_05_04":
				case "cat_step_05_06":
				case "cat_step_05_08": {
					suggestText = "วาดหน้าแมวลงไป เสร็จเรียบร้อย";
					break;
				}

				case "cat_step_05_01":
				case "cat_step_05_03":
				case "cat_step_05_05":
				case "cat_step_05_07": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				
			}
		
		return suggestText;
	}



public string craneSuggestText(string targetFoundName){
		string suggestText = "";

			switch(targetFoundName){
				case "crane_step_00": {
					suggestText = "พับครึ่งกระดาษตามรอยประ";
					break;
				}

				case "crane_step_01_01":
				case "crane_step_01_02":
				case "crane_step_01_03":
				case "crane_step_01_04": {
					suggestText = "พับครึ่งกระดาษตามมรอยประ";
					break;
				}

				case "crane_step_02_01":
				case "crane_step_02_02":
				case "crane_step_02_03":
				case "crane_step_02_04": {
					suggestText = "พับครึ่งกระดาษตามมรอยประ";
					break;
				}

				case "crane_step_03_01":
				case "crane_step_03_04":
				case "crane_step_03_05":
				case "crane_step_03_07":{
					suggestText = "กลับด้านกระดาษ ดึงกระดาษตามที่ลูกศรลงมา แล้วพับมาด้านล่างให่เป็นรูปสี่เหลี่ยม";
					break;
				}

				case "crane_step_03_02":
				case "crane_step_03_03":
				case "crane_step_03_06":
				case "crane_step_03_08": 
				case "crane_step_03_09":
				case "crane_step_03_10":
				case "crane_step_03_11":
				case "crane_step_03_12":
				case "crane_step_03_13":
				case "crane_step_03_14":
				case "crane_step_03_15":
				case "crane_step_03_16": {
					suggestText = "ดึงกระดาษตามที่ลูกศรลงมา แล้วพับมาด้านล่างให่เป็นรูปสี่เหลี่ยม";
					break;
				}


				case "crane_step_04_01":
				case "crane_step_04_02":
				case "crane_step_04_03":
				case "crane_step_04_04": {
					suggestText = "พับกระดาษขึ้นตามรอยประ ทั้งด้านหน้าและด้านหลัง";
					break;
				}


				case "crane_step_05_02":
				case "crane_step_05_04":
				case "crane_step_05_06":
				case "crane_step_05_08": {
					suggestText = "พับกระดาษขึ้นตามรอยประ ทั้งด้านหน้าและด้านหลัง";
					break;
				}

				case "crane_step_05_01":
				case "crane_step_05_03":
				case "crane_step_05_05":
				case "crane_step_05_07": {
					suggestText = "คลี่กระดาษออก";
					break;
				}

				case "crane_step_06_01":
				case "crane_step_06_02":
				case "crane_step_06_03":
				case "crane_step_06_04": 
				case "crane_step_07_02":
				case "crane_step_07_04":
				case "crane_step_07_06":
				case "crane_step_07_08":{
					suggestText = "เปิดกระดาษด้านบนขึ้น พับตามรอยพับของกระดาษ";
					break;
				}
				

				case "crane_step_07_01":
				case "crane_step_07_03":
				case "crane_step_07_05":
				case "crane_step_07_07": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "crane_step_08_01":
				case "crane_step_08_02":
				case "crane_step_08_03":
				case "crane_step_08_04":
				case "crane_step_09_01":
				case "crane_step_09_02":
				case "crane_step_09_03":
				case "crane_step_09_04":
				case "crane_step_09_05":
				case "crane_step_09_06":
				case "crane_step_09_07":
				case "crane_step_09_08": {
					suggestText = "พับกระดาษเข้ามาหากึ่งกลางตามรอบประ";
					break;
				}

				case "crane_step_10_01":
				case "crane_step_10_02":
				case "crane_step_10_03":
				case "crane_step_10_04": {
					suggestText = "พับกระดาษเข้าด้านในตามลูกศร เพื่อทำเป็นหัวและหางนก";
					break;
				}

				case "crane_step_11_01":
				case "crane_step_11_02":
				case "crane_step_11_03":
				case "crane_step_11_04":
				case "crane_step_11_05":
				case "crane_step_11_06":
				case "crane_step_11_07":
				case "crane_step_11_08": {
					suggestText = "พับกระดาษเข้าด้านในตามลูกศร เพื่อทำเป็นหัวและหางนก";
					break;
				}

				case "crane_step_12_01":
				case "crane_step_12_02":
				case "crane_step_12_03":
				case "crane_step_12_04": {
					suggestText = "ดึงกระดาษส่วนปีกออกจากกัน พับส่วนหัวและหางของนกลง";
					break;
				}


			}
		
		return suggestText;
	}



public string fishSuggestText(string targetFoundName){
		string suggestText = "";

			switch(targetFoundName){
				case "crane_step_00": {
					suggestText = "พับครึ่งกระดาษตามรอยประ";
					break;
				}

				case "fish_step_01_01":
				case "fish_step_01_02":
				case "fish_step_01_03":
				case "fish_step_01_04":
				case "fish_step_01_01":
				case "fish_step_01_02":
				case "fish_step_01_03":
				case "fish_step_01_04": {
					suggestText = "พับครึ่งกระดาษให้เกิดรอยพับ แล้วคลี่ออก";
					break;
				}

				case "fish_step_02_01":
				case "fish_step_02_02":
				case "fish_step_02_03":
				case "fish_step_02_04":
				case "fish_step_02_01":
				case "fish_step_02_02":
				case "fish_step_02_03":
				case "fish_step_02_04": {
					suggestText = "พับครึ่งกระดาษให้เกิดรอยพับ แล้วคลี่ออก";
					break;
				}

				case "fish_step_03_02":
				case "fish_step_03_03":
				case "fish_step_03_05":
				case "fish_step_03_07":
				case "fish_step_03_08":
				case "fish_step_03_11":
				case "fish_step_03_13":
				case "fish_step_03_15": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "fish_step_03_01":
				case "fish_step_03_04":
				case "fish_step_03_06":
				case "fish_step_03_09":
				case "fish_step_03_10":
				case "fish_step_03_12":
				case "fish_step_03_14":
				case "fish_step_03_16": {
					suggestText = "พับกระดาษขึ้นด้านบนตามมรอยประ";
					break;
				}


				case "fish_step_04_01":
				case "fish_step_04_03":
				case "fish_step_04_05":
				case "fish_step_04_07":
				case "fish_step_04_01":
				case "fish_step_04_03":
				case "fish_step_04_05":
				case "fish_step_04_07": {
					suggestText = "พับกระดาษลงตามมรอยประ";
					break;
				}

				case "fish_step_04_01":
				case "fish_step_04_03":
				case "fish_step_04_05":
				case "fish_step_04_07":
				case "fish_step_04_01":
				case "fish_step_04_03":
				case "fish_step_04_05":
				case "fish_step_04_07":  {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				
			}
		
		return suggestText;
	}







}
