using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class ConnectDB : MonoBehaviour { 

	public void Start(){		
		string conn = "URI=file:" + Application.dataPath + "/OrigamiGuruDB"; //Path to database.
	    IDbConnection dbconn;

	    int model_id = 1;

	    for (int step_id = 46; step_id <= 69; step_id+=1 ){
		    dbconn = (IDbConnection) new SqliteConnection(conn);

	    	dbconn.Open(); //Open connection to the database.

	    	Debug.Log(step_id);
	    	IDbCommand dbcmd = dbconn.CreateCommand();

		    string sql = "INSERT INTO Models_Steps (model_step_id,model_id,step_id) VALUES (" + step_id + "," + model_id + "," + step_id +");";

		    dbcmd.CommandText = sql;
		    IDataReader reader = dbcmd.ExecuteReader();

		    reader.Close();
	     	reader = null;
	     	dbcmd.Dispose();
	     	dbcmd = null;
	     	dbconn.Close();
	     	dbconn = null;	
		}
		
 	
     
	}
}