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
public class DefaultTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{

    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    private string suggestTextFromJSON;
    public Text suggestText;
    private GameObject canvas;
    private GameObject GettingSuggestTxtScript;
    private string targetFoundName;
    private string modelSceneName;

    #endregion // PRIVATE_MEMBER_VARIABLES


    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        canvas = GameObject.Find("Canvas");
        suggestText = canvas.GetComponentInChildren<Text>();
        modelSceneName = Application.loadedLevelName;

        Debug.Log("modelscenename is  " + modelSceneName);
    }

    void Update(){

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

        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

        targetFoundName = mTrackableBehaviour.TrackableName;
           
        getSuggestText(modelSceneName);
    }

    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
    }

    private void getSuggestText(string modelSceneName){
        GettingStepSuggestText gettingSuggestText = new GettingStepSuggestText();

        switch(modelSceneName){
            case "cat_scene": {
                suggestTextFromJSON = gettingSuggestText.catSuggestText(targetFoundName);
                break;
            }
        }

        suggestText.text = suggestTextFromJSON ;
    }

	public void OnGUI(){
		float scaleX = (float)(Screen.width)/600.0f;
		float scaleY = (float)(Screen.height)/1024.0f;
		
		GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scaleX, scaleY, 1));
    }
	
    public void nextModel(){
		string messageTrackable = mTrackableBehaviour.TrackableName;
		GameObject targetObject;
			 
		targetObject = GameObject.Find (messageTrackable);
		if (targetObject != null){
			targetObject.SetActive(false);
			Debug.Log ("LostLostLostLostLostLostLostLostLostLostLostLostLostLost");
		}
	}

    #endregion // PRIVATE_METHODS
}
