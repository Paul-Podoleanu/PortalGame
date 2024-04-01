using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    
    // The cameras sensitivity
    [SerializeField]
    float sensX;
    [SerializeField]
    float sensY;

    float _rotationX;
    float _rotationY;
    float mouseX;
    float mouseY;
    //Vector3 _rotate;
    Vector2 _mouseLook;
    Transform _playerBody;
  
  

   

    /**/
    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        _playerBody = transform.parent;
    }

    void Update()
    {
        /*
        //Creaza probleme cand se roteste camera pe vericala, deoarece se roteste si playerul vertical
        _rotationX = Input.GetAxis("Mouse X");
        _rotationY = Input.GetAxis("Mouse Y");
        _rotate = new Vector3(_rotationY, _rotationX * -_senstivity, 0);
        transform.eulerAngles = transform.eulerAngles - _rotate;
        */
         
        mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        _playerBody.Rotate(Vector3.up * mouseX);

    }

    
}
