using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] GameObject objectModel;
    [SerializeField] public GameObject objectTransparent;
    [SerializeField] Transform instantiationParent;


    [HideInInspector] public bool instantiated = false;
    PlaneTouchIndicator currentPTI;

    private void Start()
    {
        currentPTI = GetComponent<PlaneTouchIndicator>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            AddModel();
    }

    void AddModel()
    {
        if (currentPTI.isActive && !instantiated)
        {
            objectTransparent.SetActive(false);
            GameObject Temp = Instantiate(objectModel, currentPTI.transform.position, currentPTI.transform.rotation);
            Temp.transform.parent = instantiationParent;
            instantiated = true;
        }
        
    }


}
