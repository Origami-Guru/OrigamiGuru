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
					suggestText = "พลิกกระดาษด้านที่เป็นสีขาวขึ้น เลือกมุมของกระดาษด้านหนึ่ง แล้วพับเข้ามาดังภาพ";
					break;
				}

				case "fish_step_01_01":
				case "fish_step_01_03":
				case "fish_step_01_05":
				case "fish_step_01_07":{
					suggestText = "พับครึ่งกระดาษเข้าหากันตามรอยประ";
					break;
				}

				case "fish_step_01_02":
				case "fish_step_01_04":
				case "fish_step_01_06":
				case "fish_step_01_08": {
					suggestText = "พับครึ่งกระดาษให้พอดีกันตามรอยประ";
					break;
				}

				case "fish_step_02_01":
				case "fish_step_02_02":
				case "fish_step_02_03":
				case "fish_step_02_04":
				case "fish_step_02_05":
				case "fish_step_02_06":
				case "fish_step_02_07":
				case "fish_step_02_08": {
					suggestText = "พับกระดาษตามรอยประ จากด้านบนลงมาด้านล่าง";
					break;
				}

				case "fish_step_03_01":
				case "fish_step_03_03":
				case "fish_step_03_05":
				case "fish_step_03_06":
				case "fish_step_03_09":
				case "fish_step_03_11":
				case "fish_step_03_13":
				case "fish_step_03_15": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "fish_step_03_02":
				case "fish_step_03_04":
				case "fish_step_03_07":
				case "fish_step_03_08":
				case "fish_step_03_10":
				case "fish_step_03_12":
				case "fish_step_03_14":
				case "fish_step_03_16": {
					suggestText = "พับกระดาษตามรอยประ จากด้านล่างพับขึ้นไปด้านบน";
					break;
				}


				case "fish_step_04_01":
				case "fish_step_04_02":
				case "fish_step_04_03":
				case "fish_step_04_04":
				case "fish_step_04_05":
				case "fish_step_04_06":
				case "fish_step_04_07":
				case "fish_step_04_08":
				case "fish_step_04_09":
				case "fish_step_04_10":
				case "fish_step_04_11":
				case "fish_step_04_12":
				case "fish_step_04_13":
				case "fish_step_04_14":
				case "fish_step_04_15":
				case "fish_step_04_16":  {
					suggestText = "เสร็จเรียบร้อย";
					break;
				}

				
			}
		
		return suggestText;
	}



public string foxfaceSuggestText(string targetFoundName){
		string suggestText = "";

			switch(targetFoundName){
				case "crane_step_00": {
					suggestText = "พับครึ่งกระดาษตามมรอยประ";
					break;
				}

				case "fox_face_step_01_01":
				case "fox_face_step_01_02":
				case "fox_face_step_01_03":
				case "fox_face_step_01_04":{
					suggestText = "พับกระดาษลงมาตามรอยประ";
					break;
				}

				case "fox_face_step_02_01":
				case "fox_face_step_02_03":
				case "fox_face_step_02_05":
				case "fox_face_step_02_07":
				{
					suggestText = "พับกระดาษทั้ง2ด้านขึ้นด้านบนตามรอยประ";
					break;
				}

				case "fox_face_step_02_02":
				case "fox_face_step_02_04":
				case "fox_face_step_02_06":
				case "fox_face_step_02_08": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "fox_face_step_03_02":
				case "fox_face_step_03_04":
				case "fox_face_step_03_06":
				case "fox_face_step_03_08":
				case "fox_face_step_03_10":
				case "fox_face_step_03_12":
				case "fox_face_step_03_14":
				case "fox_face_step_03_16": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "fox_face_step_03_01":
				case "fox_face_step_03_03":
				case "fox_face_step_03_05":
				case "fox_face_step_03_07":
				case "fox_face_step_03_09":
				case "fox_face_step_03_11":
				case "fox_face_step_03_13":
				case "fox_face_step_03_15": {
					suggestText = "พับกระดาษตามรอยประ จากด้านล่างพับขึ้นไปด้านบน";
					break;
				}


				case "fox_face_step_04_01":
				case "fox_face_step_04_04":
				case "fox_face_step_04_06":
				case "fox_face_step_04_08": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "fox_face_step_04_02":
				case "fox_face_step_04_03":
				case "fox_face_step_04_05":
				case "fox_face_step_04_07": {
					suggestText = "วาดหน้าหมาป่า เสร็จเรียบร้อย";
					break;
				}

				
			}
		
		return suggestText;
	}



public string foxSuggestText(string targetFoundName){
		string suggestText = "";

			switch(targetFoundName){
				case "crane_step_00": {
					suggestText = "พับครึ่งกระดาษตามมรอยประ";
					break;
				}

				case "fox_step_01_01":
				case "fox_step_01_02":
				case "fox_step_01_03":
				case "fox_step_01_04":{
					suggestText = "พับกระดาษขึ้นด้านบนตามรอยประ";
					break;
				}

				case "fox_step_02_01":
				case "fox_step_02_03":
				case "fox_step_02_05":
				{
					suggestText = "พับกระดาษไปด้านหลังให้ชนกัน";
					break;
				}

				case "fox_step_02_02":
				case "fox_step_02_04":
				case "fox_step_02_06":
				case "fox_step_02_07":
				case "fox_step_02_08": {
					suggestText = "พับครึ่งกระดาษเข้าหากันตามรอยประ";
					break;
				}

				case "fox_step_03_01":
				case "fox_step_03_02":
				case "fox_step_03_03":
				case "fox_step_03_04":
				case "fox_step_03_05":
				case "fox_step_03_06":
				case "fox_step_03_07":
				case "fox_step_03_08": {
					suggestText = "พับกระดาษตามรอยประ";
					break;
				}

				case "fox_step_04_01":
				case "fox_step_04_02":
				case "fox_step_04_03":
				case "fox_step_04_04":
				case "fox_step_04_05":
				case "fox_step_04_06":
				case "fox_step_04_07":
				case "fox_step_04_08": {
					suggestText = "เปิดหน้ากระดาษตรงกลาง แล้วพับส่วนบนลง";
					break;
				}

				case "fox_step_04_09":
				case "fox_step_04_10":
				case "fox_step_04_11":
				case "fox_step_04_12":
				case "fox_step_04_13":
				case "fox_step_04_14":
				case "fox_step_04_15":
				case "fox_step_04_16": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "fox_step_05_01":
				case "fox_step_05_02":
				case "fox_step_05_03":
				case "fox_step_05_04":
				case "fox_step_05_05":
				case "fox_step_05_06":
				case "fox_step_05_07":
				case "fox_step_05_08": {
					suggestText = "พับสามเหลี่ยมเข้ามาเป็นหางของหมาป่า";
					break;
				}


				
			}
		
		return suggestText;
	}



public string pigeonSuggestText(string targetFoundName){
		string suggestText = "";

			switch(targetFoundName){
				case "crane_step_00": {
					suggestText = "พลิกกระดาษด้านที่เป็นสีขาวขึ้น เลือกมุมของกระดาษด้านหนึ่ง แล้วพับเข้ามาดังภาพ";
					break;
				}

				case "pigeon_step_01_01":
				case "pigeon_step_01_02":
				case "pigeon_step_01_03":
				case "pigeon_step_01_04":
				case "pigeon_step_02_01":
				case "pigeon_step_02_02":
				case "pigeon_step_02_03":
				case "pigeon_step_02_04":
				{
					suggestText = "พับครึ่งกระดาษตามมรอยประ แล้วคลี่ออก";
					break;
				}

				case "pigeon_step_03_01":
				case "pigeon_step_03_03":
				case "pigeon_step_03_05":
				case "pigeon_step_03_07": {
					suggestText = "กลับด้านกระดาษ";
					break;
				}

				case "pigeon_step_03_02":
				case "pigeon_step_03_04":
				case "pigeon_step_03_06":
				case "pigeon_step_03_08": {
					suggestText = "พับกระดาษตามรอยประ แล้วเปิดกระดาษตรงกลางออก1แผ่น";
					break;
				}

				case "pigeon_step_04_02":
				case "pigeon_step_04_04":
				case "pigeon_step_04_06":
				case "pigeon_step_04_08":{
					suggestText = "พับกระดาษตามรอยประ จากด้านล่างพับขึ้นไปด้านบน";
					break;
				}

				case "pigeon_step_04_01":
				case "pigeon_step_04_03":
				case "pigeon_step_04_05":
				case "pigeon_step_04_07": {
					suggestText = "พับกระดาษลงมาด้านล่างตามรอยประ";
					break;
				}

				case "pigeon_step_05_01":
				case "pigeon_step_05_02":
				case "pigeon_step_05_03":
				case "pigeon_step_05_04":
				case "pigeon_step_05_05":
				case "pigeon_step_05_06":
				case "pigeon_step_05_07":
				case "pigeon_step_05_08": {
					suggestText = "พับกระดาษขึ้นด้านบนตามรอยประ";
					break;
				}

				case "pigeon_step_06_01":
				case "pigeon_step_06_02":
				case "pigeon_step_06_03":
				case "pigeon_step_06_04":
				case "pigeon_step_06_05":
				case "pigeon_step_06_06":
				case "pigeon_step_06_07":
				case "pigeon_step_06_08": {
					suggestText = "พับกระดาษตามลูกศรลงมาเป็นส่วนของปาก";
					break;
				}


				case "pigeon_step_07_01":
				case "pigeon_step_07_02":
				case "pigeon_step_07_03":
				case "pigeon_step_07_04":
				case "pigeon_step_07_05":
				case "pigeon_step_07_06":
				case "pigeon_step_07_07":
				case "pigeon_step_07_08":
				case "pigeon_step_07_09":
				case "pigeon_step_07_10":
				case "pigeon_step_07_11":
				case "pigeon_step_07_12":
				case "pigeon_step_07_13":
				case "pigeon_step_07_14":
				case "pigeon_step_07_15":
				case "pigeon_step_07_16": {
					suggestText = "เสร็จเรียบร้อย";
					break;
				}

				
			}
		
		return suggestText;
	}


}
