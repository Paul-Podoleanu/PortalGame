using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public bool CheckWallFront()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.right, out hit, 1))
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit, 1))
        {
            if (hit.collider.tag == "Wall")
            {
                return true;
            }
        }
        
        return false;
    }
}
