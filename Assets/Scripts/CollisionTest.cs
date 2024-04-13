using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    [SerializeField]
    public GameObject firstPortal;
    
    [SerializeField]
    public GameObject secondPortal;
    public WallCheck wallCheck;


    void Start()
    {
        wallCheck = GameObject.FindObjectOfType<WallCheck>();
        //collisionTest = GameObject.FindObjectOfType<CollisionTest>();

    }

    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        //If the object collides with an object that has the tag "Portal1", print "Collision Detected"
        if (other.gameObject.tag == "FirstPortal")
        {
            Debug.Log("First Portal collision detected");
            //Check if the second portal exists
            if (secondPortal != null)
            {
                //Get the position of the second portal
                Vector3 position = secondPortal.transform.position;
                Quaternion rotation = secondPortal.transform.rotation * Quaternion.Euler(0, 180, 0);

                Vector3 exitDirection = rotation * Vector3.left;
                //Vector3 portalDirection = other.transform.forward;

                Vector3 newPosition = position + exitDirection * 2;

                transform.position = newPosition;
            }
        }

        if (other.gameObject.tag == "SecondPortal")
        {
            Debug.Log("Second portal collision detected");
            //Check if the first portal exists
            if (firstPortal != null)
            {
                //Get the position of the first portal
                Vector3 position = firstPortal.transform.position;
                Quaternion rotation = firstPortal.transform.rotation * Quaternion.Euler(0, 180, 0);

                Vector3 exitDirection = rotation * Vector3.left;
                //Vector3 portalDirection = other.transform.forward;

                Vector3 newPosition = position + exitDirection * 2;

                transform.position = newPosition;
            }
        }


        if (other.gameObject.tag == "Death")
        {
            ReloadScene();
        }

        if (other.gameObject.tag == "End")
        {
            Debug.Log("Player reached the finish line");

            // Play the finish sound
            //_soundManager.PlaySound(_finishSound);


            //Check if the current level
            switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)
            {
                case 1:
                    // Load the next level
                    UnityEngine.SceneManagement.SceneManager.LoadScene(2);
                    break;
                
                case 2:
                    // Load the next level
                    UnityEngine.SceneManagement.SceneManager.LoadScene(3);
                    break;

                case 3:
                    // Load the next level
                    UnityEngine.SceneManagement.SceneManager.LoadScene(4);
                    break;

                default:
                    //Reload the first level
                    UnityEngine.SceneManagement.SceneManager.LoadScene(4);
                    break;
            }
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
