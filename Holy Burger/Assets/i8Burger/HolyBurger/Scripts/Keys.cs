using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour, IReseatable
{
	public bool isUsed = false;
	public ingredients Typeingredients;
	bool inBurger = false;
	public bool center = false;

    void Start()
	{
		inBurger = false;
    	
        AddToList();
    }

    public void ResetObjects()
    {
	    isUsed = false;
	    this.transform.GetChild(0).gameObject.SetActive(true);
	    //this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    public void AddToList()
    {
        GameController.Instance.resetableObjects.Add(this);
    }
    
    
	private void OnTriggerEnter(Collider col)
	{
		if(isUsed)
			return;
			
		if(col.gameObject.layer != 11)
			return;
		
		Doors door = col.gameObject.GetComponent<Doors>();
		
		if (door != null)
		{
			isUsed = (col.gameObject.GetComponent<Doors>().Open(Typeingredients));
			
			if(isUsed)
				this.transform.GetChild(0).gameObject.SetActive(false);
				//	this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		}
		else //head
			{
				Debug.Log("Hit Door");
			BurgerDoor bd = col.gameObject.GetComponent<BurgerDoor>();
			
			if(bd != null)
				bd.Open();
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