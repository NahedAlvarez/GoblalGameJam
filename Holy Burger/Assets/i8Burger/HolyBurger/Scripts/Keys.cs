using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour,IReseatable
{
	public bool isUsed;
	public ingredients Typeingredients;
	bool inBurger = false;

    void Start()
	{
		inBurger = false;
    	
        AddToList();
    }

    public void OnTake()
    {
        
        gameObject.SetActive(false); 
    }

    public void ResetObjects()
    {
        isUsed = false;
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
		}
	}
    
}

public enum ingredients
{
Lettuce,
tomatos,
Cheese,
Bons,
Meat
}