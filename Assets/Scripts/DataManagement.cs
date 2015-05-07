using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class DataManagement : MonoBehaviour {
	
	#region PRIVATE_MEMBER_VARIABLES

	private string targetFoundName;
	private string sql;
	private string[] modelsName;
	private string[] modelsSceneName;
	private int counter = 0;

	#endregion

	public void getModel(string stepName){
		string connection = "URI=file:" + Application.dataPath + "/OrigamiGuruDB"; //Path to database.
		IDbConnection db_connection;

	    db_connection = (IDbConnection) new SqliteConnection(connection);
	    db_connection.Open();
	    IDbCommand db_command = db_connection.CreateCommand();	

	    sql = @"SELECT DISTINCT Models.model_name, Models.modelsSceneName
				FROM Steps
				INNER JOIN Models_Steps
				ON Steps.step_id = Models_Steps.step_id
				INNER JOIN Models
				ON Models_Steps.model_id = Models.model_id
				WHERE step_name = " + stepName;
	    db_command.CommandText = sql;
		IDataReader reader = db_command.ExecuteReader();

		while(reader.Read()){
			modelsName[counter] = reader.GetString(0);
			modelsSceneName[counter] = reader.GetString(1);
			Debug.Log("Query from database : model_name = " + modelsName + ", model_scene_name = " + modelsSceneName);
			counter += 1;
		}

		reader.Close();
		reader = null;
		db_command.Dispose();
		db_command = null;
		db_connection.Close();
		db_connection = null;		
	}
}
