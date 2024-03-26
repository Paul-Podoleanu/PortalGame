using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    
    [SerializeField]
    float _senstivity = -2f;

    float _rotationX ;
    float _rotationY;
    Vector3 _rotate;
  

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _rotationX = Input.GetAxis("Mouse X");
        _rotationY = Input.GetAxis("Mouse Y");
        _rotate = new Vector3(_rotationY, _rotationX * -_senstivity, 0);
        transform.eulerAngles = transform.eulerAngles - _rotate;

    }
}
