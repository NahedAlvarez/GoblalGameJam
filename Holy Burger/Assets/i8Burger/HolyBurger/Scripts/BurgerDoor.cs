using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BurgerDoor : MonoBehaviour
{
	public List<Keys> allKeys;
	public Collider doorCollider;
	public UnityEvent openDoorAction;
	public Burger burger;
	
	//Called by the editor
	void Reset()
	{
		doorCollider = this.GetComponent<Collider>();
		GameObject keyParent = GameObject.Find("Keys");
		
		if(keyParent != null)
			allKeys.AddRange(keyParent.GetComponentsInChildren<Keys>());
			
			
		GameObject burgerObject = GameObject.Find("Burger");
		
		if(burgerObject != null)
			burger = burgerObject.GetComponent<Burger>();
	}

	public void Start()
	{
		doorCollider = GetComponent<Collider>();
	}
    
    
	public bool Open()
	{
		Debug.Log("Open burger Door: " + burger.allIngredientsFound.Count);
		if (burger.allIngredientsFound.Count == allKeys.Count)
		{
			doorCollider.enabled = false;
			openDoorAction.Invoke();
	        
			return true;
		}
        
		return false;
	}
}
