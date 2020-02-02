using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[RequireComponent(Collider)]
public class Doors : MonoBehaviour,IReseatable
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
        AddToList();
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

    public void ResetObjects()
    {
        doorCollider.enabled = true;
    }

    public void AddToList()
    {
        GameController.Instance.resetableObjects.Add(this);
    }
}
