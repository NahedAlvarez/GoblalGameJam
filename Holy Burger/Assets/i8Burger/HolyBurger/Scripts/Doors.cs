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
	public bool Open(ingredients _keyType)
    {
        if (_keyType == keyType)
        {
        	AudioManager.Instance.SelectAudio(ConvertKeyTipeAName(keyType));
	        doorCollider.enabled = false;
	        openDoorAction.Invoke();
	        
	        return true;
        }
        
	    return false;
    }

	string ConvertKeyTipeAName(ingredients key)
	{
		switch(key)
		{
			case ingredients.Cheese:
				return "cheese-door";
			case ingredients.Lettuce:
				return "lettuce-door";
			case ingredients.Meat:
				return "meat-door";
			case ingredients.tomatos:
				return "tomato-door";
			default: 
				return null;
		}
	}
}
