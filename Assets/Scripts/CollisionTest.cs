using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPortal;
    
    [SerializeField]
    private GameObject secondPortal;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //If the object collides with an object that has the tag "Portal1", print "Collision Detected"
        if (collision.gameObject.tag == "FirstPortal")
        {
            Debug.Log("Collision Detected");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //If the object collides with an object that has the tag "Portal1", print "Collision Detected"
        if (other.gameObject.tag == "FirstPortal")
        {
            Vector3 position = secondPortal.transform.position;
            transform.position = position + new Vector3(1, 0, 0);
        }

        if (other.gameObject.tag == "SecondPortal")
        {
            Debug.Log("Second portal collision detected");
            Vector3 position = firstPortal.transform.position;
            transform.position = position + new Vector3(-1, 0, 0);
        }
    }

}
