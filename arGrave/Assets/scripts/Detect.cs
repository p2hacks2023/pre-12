using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class Detect : MonoBehaviour
{
    public GameObject Emitter;
    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    bool ifWatered;

    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {

        GameObject directorObject = GameObject.Find("UIdirector");
        UIdirector director = directorObject.GetComponent<UIdirector>();
        ifWatered = director.ifWaterMode;


        if (ifWatered)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)  // when you touch the screen
                {
                    if (arRaycastManager.Raycast(touch.position, hits, TrackableType.Image))//PlaneWithinPolygon
                    {
                        Pose hitPose = hits[0].pose;  //RayÇ∆ARPlaneÇ™è’ìÀÇµÇ∆Ç±ÇÎÇÃPose
                        Instantiate(Emitter, hitPose.position, hitPose.rotation);  // emit particle
                        Emitter.GetComponent<ParticleSystem>().Play();

                        director.CountWaterTime();
                        GetComponent<AudioSource>().Play();
                    }
                }
            }
        }
    }


}
