using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{

    public Vector3 GetWallNormal()
    {
        Vector3[] directions = { transform.forward, -transform.forward, transform.right, -transform.right };

        foreach (Vector3 dir in directions)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, 1.0f))
            {
                return hit.normal;
            }
        }

        // If no ray hits a wall, return Vector3.zero
        return Vector3.zero;
    }

    public bool CheckWallFront()
    {
        Debug.Log("Checking wall front");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, 1.0f))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckWallBack()
    {
        Debug.Log("Checking wall back");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit, 1.0f))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool CheckWallLeft()
    {
        Debug.Log("Checking wall left");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 1.0f))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }
        
        return false;
    }

    public bool CheckWallRight()
    {
        Debug.Log("Checking wall right");
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }
        
        return false;
    }
}
