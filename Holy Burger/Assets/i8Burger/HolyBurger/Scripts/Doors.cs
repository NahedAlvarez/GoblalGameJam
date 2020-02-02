using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(Collider)]
public class Doors : MonoBehaviour
{
    public ingredients keyType;
    public Collider doorCollider;
	public UnityEvent openDoorAction;

	//Called by the editor
	void Reset()
	{
		doorCollider = this.GetComponent<Collider>();
	}

    public void Start()
    {
        doorCollider = GetComponent<Collider>();
    }
	public bool Open(ingredients keyType)
    {
        if (keyType == keyType)
        {
	        doorCollider.enabled = false;
	        openDoorAction.Invoke();
	        
	        return true;
        }
        
	    return false;
    }

}
