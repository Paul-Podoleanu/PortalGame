using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField]
    int _MovementSpeed, _JumpForce;

    void Start()
    {
        
    }


    void Update()
    {
        //Move the player horizontally without pressing specific keys
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * _MovementSpeed * Time.deltaTime);

        //Move the player vertically without pressing specific keys
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * _MovementSpeed * Time.deltaTime);

        //When the Space key is pressed, move the player up
        //Apply force to the player to make it jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
        }

    }
}