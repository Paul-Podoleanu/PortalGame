using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPortalShot : MonoBehaviour
{
    public CollisionTest collisionTest;
    public GameObject firstPortalPrefab;

    void Start()
    {
        collisionTest = GameObject.FindObjectOfType<CollisionTest>();  
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            //Instantiate the first portal and set the position and rotation of the portal so thet it faces oppoiste of the wall
            GameObject portal = Instantiate(firstPortalPrefab, new Vector3(transform.position.x, transform.position.y -1.0f, transform.position.z), other.transform.rotation);
            portal.transform.eulerAngles = new Vector3(portal.transform.eulerAngles.x, portal.transform.eulerAngles.y -90f, portal.transform.eulerAngles.z);

            //GameObject portal = Instantiate(firstPortalPrefab, new Vector3(transform.position.x - .3f, transform.position.y - .5f, transform.position.z), other.transform.rotation);
            //portal.transform.eulerAngles = new Vector3(portal.transform.eulerAngles.x, portal.transform.eulerAngles.y + 90f, portal.transform.eulerAngles.z);
            //Set the tag of the portal to "FirstPortal"
            portal.tag = "FirstPortal";
            collisionTest.DestroyFirstPortal();
            collisionTest.firstPortal = portal;

            //Set the first portal to the portal that was just created
            collisionTest.SetFirstPortal(portal);

            Destroy(gameObject);
        }
    }
}
