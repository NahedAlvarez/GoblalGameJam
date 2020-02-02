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
    public void Open(Keys key)
    {
        if (key.Typeingredients == keyType && key.isUsed == false)
        {
            key.isUsed = true;
	        doorCollider.enabled = false;
	        openDoorAction.Invoke();
        }
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
