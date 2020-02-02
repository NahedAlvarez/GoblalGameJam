using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BurgerDoor : MonoBehaviour
{
	public List<Keys> allKeys;
	public Collider doorCollider;
	public UnityEvent openDoorAction;
	
	//Called by the editor
	void Reset()
	{
		doorCollider = this.GetComponent<Collider>();
		GameObject keyParent = GameObject.Find("Keys");
		
		if(keyParent != null)
			allKeys.AddRange(keyParent.GetComponentsInChildren<Keys>());
	}

	public void Start()
	{
		doorCollider = GetComponent<Collider>();
	}
    
    
	public bool Open(Burger burger)
	{
		if (burger.allIngredientsFound.Count == allKeys.Count)
		{
			doorCollider.enabled = false;
			openDoorAction.Invoke();
	        
			return true;
		}
        
		return false;
	}
}
