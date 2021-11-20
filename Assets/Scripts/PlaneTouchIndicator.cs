using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneTouchIndicator : MonoBehaviour
{
    ARRaycastManager rayManager;
    ObjectSpawner objectSpawner;
    GameObject objectTransparent;

    [HideInInspector] public bool isActive = false;


    void Start()
    {
        objectSpawner = GetComponent<ObjectSpawner>();
        rayManager = FindObjectOfType<ARRaycastManager>();
        objectTransparent = objectSpawner.objectTransparent;
        objectTransparent.SetActive(false);
    }

    void Update()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            // enable the visual if it's disabled
            if (!objectTransparent.activeInHierarchy && !objectSpawner.instantiated)
            {
                objectTransparent.SetActive(true);
                isActive = true;
            }
        }
    }
}