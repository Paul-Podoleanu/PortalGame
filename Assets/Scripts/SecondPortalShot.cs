using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPortalShot : MonoBehaviour
{
    public CollisionTest collisionTest;
    public GameObject secondPortalPrefab;

    void Start()
    {
        //collisionTest = FindObjectsOfType<CollisionTest>()[0];
        collisionTest = GameObject.FindObjectOfType<CollisionTest>();
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            GameObject portal = Instantiate(secondPortalPrefab, new Vector3(transform.position.x + .3f, transform.position.y - .5f, transform.position.z), other.transform.rotation);
            portal.transform.eulerAngles = new Vector3(portal.transform.eulerAngles.x, portal.transform.eulerAngles.y + 90f, portal.transform.eulerAngles.z);
            //Set the tag of the portal to "SecondPortal"
            portal.tag = "SecondPortal";
            collisionTest.DestroySecondPortal();
            collisionTest.secondPortal = portal;

            //Set the second portal to the portal that was just created
            collisionTest.SetSecondPortal(portal);

            Destroy(gameObject);
        }
    }
}
