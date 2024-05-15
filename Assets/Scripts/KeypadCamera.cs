using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadCamera : MonoBehaviour
{

    public GameObject primaryCamera;
    public GameObject cameraKeypad;
    
    public GameObject player;

    public GameObject layerKey;
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            primaryCamera.SetActive(true); 
            cameraKeypad.SetActive(false);
            layerKey.SetActive(false);
              
        }
    }

    private void OnMouseDown(){
        cameraKeypad.SetActive(true);
        layerKey.SetActive(true);
        primaryCamera.SetActive(false);  
    }
}
