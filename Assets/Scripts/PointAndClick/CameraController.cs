using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public GameObject player;
    [SerializeField] private float xAxis, yAxis, zAxis;
    public Vector3 zoomAmount;
    public Vector3 newZoom;
    // Start is called before the first frame update
    void Start()
    {
        newZoom = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xAxis, player.transform.position.y + yAxis, player.transform.position.z + zAxis);
        HandleMouseInput();
    }

    void HandleMouseInput(){
        if(Input.mouseScrollDelta.y != 0){
            newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }
    }
}