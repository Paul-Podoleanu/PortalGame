using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField]
    public GameObject firstPortal;
    
    [SerializeField]
    public GameObject secondPortal;


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
            Debug.Log("First Portal collision detected");
            //Check if the second portal exists
            if (secondPortal != null)
            {
                //Get the position of the second portal
                Vector3 position = secondPortal.transform.position;
                //Set the position of the object to the position of the second portal
                transform.position = position + new Vector3(1, 0, 0);
            }
        }

        if (collision.gameObject.tag == "SecondPortal")
        {
            Debug.Log("Second portal collision detected");
            //Check if the first portal exists
            if (firstPortal != null)
            {
                //Get the position of the first portal
                Vector3 position = firstPortal.transform.position;
                //Set the position of the object to the position of the first portal
                transform.position = position + new Vector3(-1 , 0, 0);
            }
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        //If the object collides with an object that has the tag "Portal1", print "Collision Detected"
        if (other.gameObject.tag == "FirstPortal")
        {
            Debug.Log("First Portal collision detected");
            Vector3 position = secondPortal.transform.position;
            transform.position = position + new Vector3(1, 0, 0);
        }

        if (other.gameObject.tag == "SecondPortal")
        {
            Debug.Log("Second portal collision detected");
            Vector3 position = firstPortal.transform.position;
            transform.position = position + new Vector3(-1 , 0, 0);
        }

        if (other.gameObject.tag == "Spike")
        {
            ReloadScene();
        }

        if (other.gameObject.tag == "End")
        {
            Debug.Log("Level finished");
        }
    }

    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void DestroyFirstPortal()
    {
        //Check if the first portal exists
        if (firstPortal != null)
        {
            //Destroy the first portal
            Destroy(firstPortal);
        }
    }

    public void DestroySecondPortal()
    {
        //Check if the second portal exists
        if (secondPortal != null)
        {
            //Destroy the second portal
            Destroy(secondPortal);
        }
    }

    public void SetFirstPortal(GameObject portal)
    {
        firstPortal = portal;
    }

    public void SetSecondPortal(GameObject portal)
    {
        secondPortal = portal;
    }

}
