/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class MainTrackableEventHandler : MonoBehaviour,
                                            ITrackableEventHandler
{
    #region PRIVATE_MEMBER_VARIABLES
 
    private TrackableBehaviour mTrackableBehaviour;
    private bool isChooseModel = false;                 //this variable means user does/doesn't choose origami model to fold.
    private bool showPopupWindow = false;
    
    #endregion // PRIVATE_MEMBER_VARIABLES

    #region PUBLIC_MEMBER_VARIABLES

    public GUIStyle windowStyle;
    public GUIStyle fontStyle;
    public GUIStyle buttonStyle;

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
        if(isChooseModel == true)
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
        }
        //user doesn't used to choose origami model to fold.
        else
        {
            //user choose origami model method.
            showPopupWindow = true;
            //ChoosingOrigamiModel choosingOrigamiModel = new ChoosingOrigamiModel();
            //choosingOrigamiModel.OnGUI();            
            Debug.Log("User should choose any model first!!!!!!!!");   
        }
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

    #endregion // PRIVATE_METHODS


    private void chooseModelContent(int windowID){
        GUI.Button(new Rect(10,30,80,20), "Choose Crane");

        if(isChooseModel == false){
            isChooseModel = true;
        }
    }

    private void OnGUI(){
        float scaleX = (float)(Screen.width)/600.0f;
        float scaleY = (float)(Screen.height)/1024.0f;

        GUI.matrix = Matrix4x4.TRS(new Vector3(0, 0, 0), Quaternion.identity, new Vector3(scaleX, scaleY, 1));
        Rect WindowRect = new Rect(30, 30, 540, 984);
        
        if(showPopupWindow == true){
            ChoosingOrigamiModel choosingOrigamiModel = new ChoosingOrigamiModel();
            choosingOrigamiModel.makewords();
            GUI.Window(1, WindowRect, chooseModelContent, "Please choose a origami model ", windowStyle);
        }

    }

}
