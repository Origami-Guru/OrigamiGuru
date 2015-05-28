/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/
using System;
using UnityEngine;
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
    private Text suggestText;
    private GameObject canvas;
    private string targetFoundName;
    private int modelID;

    private bool enableSuggestText = false;

    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_MEMBER_VARIABLES
 
    public GUIStyle suggestLabelStyle;

    #endregion // PUBLIC_MEMBER_VARIABLES

    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
        /*
        canvas = GameObject.Find("Canvas");
        suggestText = canvas.GetComponentInChildren<Text>();
        modelID = Convert.ToInt32(suggestText);
        Debug.Log("model id is " + modelID + "suggestText is " + suggestText.ToString());
        */
    }

    /*
    void Update(){
        if(enableSuggestText){
            GettingStepSuggestText gettingStep = new GettingStepSuggestText();
            suggestTextFromJSON = gettingStep.getSuggestText(modelID, targetFoundName);
            suggestText.text = suggestTextFromJSON;
        }
    } */

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
        //user used to choose origami model to fold.
        targetFoundName = mTrackableBehaviour.TrackableName;

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
        
        enableSuggestText = true;
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

	public void OnGUI(){
		float scaleX = (float)(Screen.width)/600.0f;
		float scaleY = (float)(Screen.height)/1024.0f;

        Rect suggestLabelRect = new Rect(50, 500, 400, 120);
		
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
