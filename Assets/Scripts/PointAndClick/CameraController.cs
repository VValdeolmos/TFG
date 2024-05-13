using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    public GameObject player;
    [SerializeField] private float xAxis, yAxis, zAxis;
   
    [SerializeField] private float rotationSpeed = 0.1f;
    private bool _isRotating;

    private float _xRotation;

    private Vector2 _delta;
    // Start is called before the first frame update
    private void Awake()
    {
        _xRotation = transform.rotation.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + xAxis, player.transform.position.y + yAxis, player.transform.position.z + zAxis);
        
        
        
    }

    public void OnLook(InputAction.CallbackContext context){
        _delta = context.ReadValue<Vector2>();
        //Debug.Log(_delta);
    }

    public void OnRotate(InputAction.CallbackContext context){
        _isRotating = context.started || context.performed;
    }

    private void LateUpdate(){
        if(_isRotating){
            transform.Rotate(new Vector3(_xRotation,-_delta.x * rotationSpeed, 0.0f));
            transform.rotation = Quaternion.Euler(_xRotation, transform.rotation.eulerAngles.y, 0.0f);
        }
    }

    
}