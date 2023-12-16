using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDirector : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI textText;
    int Level;



    // Update is called once per frame
    void Update()
    {
        GameObject UIdirectorObject = GameObject.Find("UIdirector");
        UIdirector UI = UIdirectorObject.GetComponent<UIdirector>();
        Level = UI.GraveLevel;

        textText.text = "Level: "+ Level;
    }
}
