using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour, IReseatable
{
	public bool isUsed = false;
	public ingredients Typeingredients;
	bool inBurger = false;

    void Start()
	{
		inBurger = false;
    	
        AddToList();
    }

    public void ResetObjects()
    {
	    isUsed = false;
	    this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void AddToList()
    {
        GameController.Instance.resetableObjects.Add(this);
    }
    
    
	private void OnTriggerEnter(Collider col)
	{
		if(isUsed)
			return;
		
		Doors door = col.gameObject.GetComponent<Doors>();
		
		if (door != null)
		{
			isUsed = (col.gameObject.GetComponent<Doors>().Open(Typeingredients));
			
			if(isUsed)
				this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
	}
    
}

public enum ingredients
{
	Lettuce,
	tomatos,
	Cheese,
	Meat,
	Pickles
}