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
    private string suggestText;
    private GameObject canvas;
    private GameObject GettingSuggestTxtScript;
    private string targetFoundName;
    private string modelSceneName;
    private GameObject targetObject;
    private SpriteRenderer[] modelImages;

    private bool showSuggestText = false;
    private bool showButtonNext = false;
    private bool showButtonBack = false;

    public GUIStyle suggestTextStyle;
    public GUIStyle buttonNextStyle;
    public GUIStyle buttonBackStyle;

    private Rect suggestTextRect = new Rect(50, 800, 500, 200);
    private Rect buttonNextRect = new Rect(500, 450, 70, 70);
    private Rect buttonBackRect = new Rect(10, 450, 70, 70);

    #endregion // PRIVATE_MEMBER_VARIABLES


    #region UNTIY_MONOBEHAVIOUR_METHODS
    
    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        modelSceneName = Application.loadedLevelName;
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
            showButtonNext = true;
            showSuggestText = true;
        }
        else
        {
            OnTrackingLost();
            showButtonNext = false;
            showSuggestText = false;
        }
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS


    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
        Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

        // Enable rendering:
        rendererComponents[0].enabled = true;
        rendererComponents[1].enabled = false;

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
        showButtonNext = false;
        showButtonBack = false;
    }

    private string getSuggestText(string modelSceneName){
        GettingStepSuggestText gettingSuggestText = new GettingStepSuggestText();

        switch(modelSceneName){
            case "cat_scene": {
                suggestTextFromJSON = gettingSuggestText.catSuggestText(targetFoundName);
                break;
            }
            case "crane_scene": {
                //suggestTextFromJSON = gettingSuggestText.craneSuggestText(targetFoundName);
                break;
            }
            case "pigeon_scene": {
                //suggestTextFromJSON = gettingSuggestText.pigeonSuggestText(targetFoundName);
                break;
            }
            case "fox_face_scene": {
                //suggestTextFromJSON = gettingSuggestText.foxfaceSuggestText(targetFoundName);
                break;
            }
            case "fox_scene": {
                //suggestTextFromJSON = gettingSuggestText.foxSuggestText(targetFoundName);
                break;
            }
            case "dog_scene": {
                //suggestTextFromJSON = gettingSuggestText.dogSuggestText(targetFoundName);
                break;
            }
        }

        suggestText = suggestTextFromJSON ;
        return suggestText;
    }
	
    public void OnGUI(){
        float scaleX = (float)(Screen.width)/600.0f;
        float scaleY = (float)(Screen.height)/1024.0f;
        
        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scaleX, scaleY, 1));
        
        if(showButtonNext == true){
            targetObject = GameObject.Find(targetFoundName);
            modelImages = targetObject.GetComponentsInChildren<SpriteRenderer>(true);
            
            if(GUI.Button(buttonNextRect, "", buttonNextStyle)){
                foreach(SpriteRenderer modelimage in modelImages){
                    Debug.Log("model image are " + modelimage);
                }
                modelImages[0].enabled = false;
                modelImages[1].enabled = true;
                showButtonNext = false;
                showButtonBack = true;
            }
        }

        if(showButtonBack == true){
            targetObject = GameObject.Find(targetFoundName);
            modelImages = targetObject.GetComponentsInChildren<SpriteRenderer>(true);
            
            if(GUI.Button(buttonBackRect, "", buttonBackStyle)){
                foreach(SpriteRenderer modelimage in modelImages){
                    Debug.Log("model image are " + modelimage);
                }
                modelImages[0].enabled = true;
                modelImages[1].enabled = false;
                showButtonNext = true;
                showButtonBack = false;
            }
        }

        if(showSuggestText == true){
            suggestText = getSuggestText(modelSceneName);
            GUI.Label(suggestTextRect, suggestText, suggestTextStyle);
        }
    }

    #endregion // PRIVATE_METHODS
}
