using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    public CollisionTest collisionTest;
    public GameObject portalPrefab;

    private void Start()
    {
        collisionTest = FindObjectsOfType<CollisionTest>()[0];
        //Debug.Log(collisionTest.name);
    }
    void OnTriggerEnter(Collider other)
    {
        //If the object collides with an object that has the tag "Portal1", print "Collision Detected"
        if (other.gameObject.tag == "FirstPortal")
        {
            Debug.Log("The first portal was hit");
            GameObject portal = Instantiate(portalPrefab, new Vector3(transform.position.x-.3f, transform.position.y-.5f, transform.position.z), other.transform.rotation);
            portal.transform.eulerAngles= new Vector3(portal.transform.eulerAngles.x, portal.transform.eulerAngles.y +90f, portal.transform.eulerAngles.z);
            Destroy(collisionTest.firstPortal);
            collisionTest.firstPortal=portal;

            Destroy(gameObject);
        }

        if (other.gameObject.tag == "SecondPortal")
        {
            Debug.Log("The second portal was hit");
            GameObject portal = Instantiate(portalPrefab, new Vector3(transform.position.x + .3f, transform.position.y - .5f, transform.position.z), other.transform.rotation);
            portal.transform.eulerAngles = new Vector3(portal.transform.eulerAngles.x, portal.transform.eulerAngles.y + 90f, portal.transform.eulerAngles.z);
            Destroy(collisionTest.secondPortal);
            collisionTest.secondPortal = portal;
            Destroy(gameObject);
        }
    }
}
