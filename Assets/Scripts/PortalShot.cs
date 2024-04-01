using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //If the object collides with an object that has the tag "Portal1", print "Collision Detected"
        if (other.gameObject.tag == "FirstPortal")
        {
            Debug.Log("The first portal was hit");
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "SecondPortal")
        {
            Debug.Log("The second portal was hit");
            Destroy(gameObject);
        }
    }
}
