using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{

    [SerializeField]
    int _MovementSpeed, _JumpForce;

    [SerializeField]
    Transform _orientation;

    [SerializeField]
    private AudioSource walkingSound;
    [SerializeField]
    private AudioSource jumpSound;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

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

        if(horizontalInput ==0 && verticalInput == 0)
        {
            walkingSound.mute=true;
        }
        if(horizontalInput != 0 || verticalInput != 0)
        {
            walkingSound.mute = false;
        }
        moveDirection = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

        //When the Space key is pressed, move the player up
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
            GetComponent<Rigidbody>().AddForce(Vector3.up * _JumpForce, ForceMode.Impulse);
        }



        // Fi the rotation of the player on the z axis si beyond 0.45, set it to 0.45 and if it is below -0.45, set it to -0.45
        if (transform.eulerAngles.z > 0.45f && transform.eulerAngles.z < 180f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0.45f);
        }

        if (transform.eulerAngles.z < 359.55f && transform.eulerAngles.z > 180f)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, -0.45f);
        }

       
        
    }

}
