/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class MainTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    private bool isChooseModel = false;                 //this variable means user does/doesn't choose origami model to fold.
    private bool foundedTarget = false;
    private string targetFoundName = "";

    private string sql;
    private string modelsName;
    private string modelsSceneName;

    private GameObject gameObject;

    private Dictionary<string, string> modelDictionary;     //dictionary to keep the query from the database for origami models
    
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_MEMBER_VARIABLES

    public GUIStyle windowStyle;
    public GUIStyle fontStyle;
    public GUIStyle buttonStyle;
    public GUIStyle gridviewStyle;

    //custom grid
    public int selGridInt = 0;
    public Texture[] selImage;
    private int selImgSize = 0;
    private int counter;
    private GUIContent[] selContent;

    #endregion

    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    void Update(){
        if(selGridInt != 0){
            
            //Debug.Log(selGridInt);
        }
    }

    #endregion // UNTIY_MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS

    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.DETECTED || 
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            modelDictionary = new Dictionary<string, string>();
            foundedTarget = true;
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
            foundedTarget = false;
        }
    }

    #endregion // PUBLIC_METHODS



    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        targetFoundName = mTrackableBehaviour.TrackableName;
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

        if(targetFoundName != null){    
            modelDictionary = GettingModels.Instance.getModel(targetFoundName);
        }

    }


    private void OnTrackingLost()
    {
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    #endregion // PRIVATE_METHODS


    private void chooseModelContent(int windowID){
        float scaleX = (float)(Screen.width)/600.0f;
        float scaleY = (float)(Screen.height)/1024.0f;

        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scaleX, scaleY, 1));       

        GUILayout.BeginVertical("Box");

        if(modelDictionary.Count != 0){
            selImgSize = modelDictionary.Count;
        }

        //selection grid begins
        counter = 0;
        selImage = new Texture[selImgSize];
        selContent = new GUIContent[selImgSize];

        foreach(KeyValuePair<string, string> md in modelDictionary){
            selImage[counter] =  Resources.Load<Texture>(md.Key);
            counter += 1;
        }

        selGridInt = GUILayout.SelectionGrid(selGridInt, selImage, 2, gridviewStyle);

        if (GUILayout.Button("OK!"))
            Debug.Log("You chose " + selImage[selGridInt]);
        
        GUILayout.EndVertical();  
    }


    private void OnGUI(){
        float scaleX = (float)(Screen.width)/600.0f;
        float scaleY = (float)(Screen.height)/1024.0f;

        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scaleX, scaleY, 1));
        Rect WindowRect = new Rect(50, 200, 500, 800);
        
        //This is only shown when the user point the camera to the origami paper. 
        if(foundedTarget == true && isChooseModel == false){
            GUI.Window(1, WindowRect, chooseModelContent, "Please choose an origami model.", windowStyle);
        }
    }    
}
