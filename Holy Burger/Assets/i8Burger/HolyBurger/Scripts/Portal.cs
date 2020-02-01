using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    public Portal otherPortal;
    float currentTimeUntilTeleport;
    float maxTimeUntilTeleport  = 1.5f;
	public bool flag = false;

    void Start() 
    {
        currentTimeUntilTeleport = maxTimeUntilTeleport;
    }
    void Update() 
    {
        if (flag == true) 
        {
            if (currentTimeUntilTeleport < 0)
            {
                flag = false;
                currentTimeUntilTeleport = maxTimeUntilTeleport;
            }
            else 
            {
	            currentTimeUntilTeleport -= Time.deltaTime;
            }
        }
    }

    public Vector3 ReturnPosition()
    {
        return transform.position;
    }

    private void OnTriggerEnter(Collider collision) 
    {
        if (collision.gameObject.GetComponent<Player>() && flag == false)
        {
	        otherPortal.flag = true;
	        flag = true;
	        collision.transform.position = otherPortal.ReturnPosition();
        }
    }
}
