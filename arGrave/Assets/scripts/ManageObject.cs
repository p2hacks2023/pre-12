using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



public class ManageObject : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabList;
    List<GameObject> newPrefabList;

    ARTrackedImageManager manager;

    GameObject directorObject;
    UIdirector director;
    int currentLevel = 0;


    private void Awake()
    {
        directorObject = GameObject.Find("UIdirector");
        director = directorObject.GetComponent<UIdirector>();

        manager = this.GetComponent<ARTrackedImageManager>();
        newPrefabList = new List<GameObject>();

        foreach(var prefab in prefabList)
        {
            var instance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            instance.SetActive(false);
            newPrefabList.Add(instance);
        }
    }

    private void OnEnable()
    {
        manager.trackedImagesChanged += onTrackedImageChanged;

    }

    private void OnDisable()
    {
        manager.trackedImagesChanged -= onTrackedImageChanged;
    }


    private void UpdateARObject(ARTrackedImage trackedImage)
    {
        
        var index = director.GraveLevel - 1;

        if (index > newPrefabList.Count - 1)
        {
            return;
        }

        var currentObject = newPrefabList[index];
        var markerTransform = trackedImage.transform;

        var markerFrontRotation = markerTransform.rotation * Quaternion.Euler(0f, 180f, 0f);//90f,0,0
        currentObject.transform.SetPositionAndRotation(markerTransform.transform.position, markerFrontRotation);
        currentObject.transform.SetParent(markerTransform);

        if (currentLevel != index)
        {
            newPrefabList[currentLevel].SetActive(false);
            currentLevel = index;
        }
        currentObject.SetActive(true);
    }

    private void onTrackedImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach(var trackedImage in eventArgs.added)
        {
            UpdateARObject(trackedImage);
        }

        foreach(var trackedImage in eventArgs.updated)
        {
            UpdateARObject(trackedImage);
        }
    }
}
