using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.Experimental.XR;
using System;


[RequireComponent(typeof(ARRaycastManager))]
public class PlaceObject : MonoBehaviour
{
    public Camera currentCamera;
    public GameObject pointer;
    public drop_point dropPoint;
   // private ARSessionOrigin arOrigin;
    ARRaycastManager raycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
   
   
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        updatePlacementPose();
    }

    private void updatePlacementPose()
    {
        Vector2 screenCentre = currentCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        
        raycastManager.Raycast(screenCentre, hits,UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;
        }
    }
    public  void placePointer()
    {
       // updatePlacementPose();
         Instantiate(pointer, placementPose.position, placementPose.rotation);
       // placementPoseIsValid = true;//***
        UI.placepointerbutton();
        

    }
    public void save()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("pointer");
        obj.GetComponent<map_pointer>().Name = UI.pointer_name_input.GetComponent<InputField>().text;
        UI.savebutton();

       
    }
    public void placeDropPoint()
    {
        map_pointer obj = GameObject.FindGameObjectWithTag("pointer").GetComponent<map_pointer>();
       
        
        drop_point drop= Instantiate(dropPoint, placementPose.position, placementPose.rotation);
        obj.drops.Add(drop);

    }
    public void saveMapButton()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("pointer");
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("droppoint"))
        {
            obj.GetComponent<map_pointer>().drops.Add(x.GetComponent<drop_point>());

        }
        
        data.writeData();
        UI.savemapbutton();
        destroy_all();
        data.readLocationsName();
        SceneChange.HomepageScene();
    }
    public  void destroy_all()
    {
        Destroy(GameObject.FindGameObjectWithTag("pointer"));
        foreach (GameObject x in GameObject.FindGameObjectsWithTag("droppoint"))
        {
            Destroy(x);

        }
       

    }
  
   
  
}
