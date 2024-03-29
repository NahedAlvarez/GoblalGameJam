﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Burger : MonoBehaviour, IReseatable
{
	
	public List<GameObject> allIngredientsFound = new List<GameObject>();
	public List<Keys> onBurger = new List<Keys>(); 
	public GameObject BunTop, BunBottom;
	//public float sizeOfIngredients = 0.1f;
	public Transform[] positions = new Transform[0];
	
	public UnityEvent onEat = new UnityEvent();
	
    // Start is called before the first frame update
    void Start()
	{
		AddToList();
        
    }

    // Update is called once per frame
    void Update()
    {
	    for(int i = 0; i < onBurger.Count; i++)
	    {
	    	if(onBurger[i].isUsed)
	    	{
	    		onBurger.RemoveAt(i);
	    		i--;
	    		
	    		UpdatePositions();
	    	}
	    }
    }
    
	public void UpdatePositions()
	{
		int x = 0;
		for(int i = 0; i < onBurger.Count; i++)
		{
			if(!onBurger[i].center)
				onBurger[i].GetComponent<CopyTransform>().target = this.positions[i-x];
			else
			{
				onBurger[i].GetComponent<CopyTransform>().target = this.positions[((int)(onBurger.Count/2f))];
				x++;
			}
		}
		
		//move bun up
		BunTop.transform.localPosition = this.positions[onBurger.Count-x].localPosition;
	}
	 
    
	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.layer == 8)
		{
			//its already in the burger
			if(allIngredientsFound.Contains(col.gameObject))
				return;
				
			//turn on kinematic rigidboard
			col.GetComponent<Rigidbody>().isKinematic = false;
			
			allIngredientsFound.Add(col.gameObject);
			onBurger.Add(col.gameObject.GetComponent<Keys>());
		
			UpdatePositions();
			AudioManager.Instance.SelectAudio("ingredient");
		}
		else 
			if (col.gameObject.layer == 9)//head
			{
				//play eat animation - TO DO
				///play eat sound - TO DO
				/// wait time until finished - TO DO
				/// 
				//reset game and play sound
				onEat.Invoke();
				AudioManager.Instance.SelectAudio("eating");
				StartCoroutine("WaitUntilEat");
			}
	}
	
	IEnumerator WaitUntilEat()
	{
		yield return new WaitForSeconds(1.5f);
		GameController.Instance.ResetGame();
		
	}
	
	public void AddToList()
	{
		GameController.Instance.resetableObjects.Add(this);
	}
	
	public void ResetObjects()
	{
		onBurger = new List<Keys>();
		
		for(int i = 0; i < allIngredientsFound.Count; i++)
		{
			onBurger.Add(allIngredientsFound[i].GetComponent<Keys>());
		}
		
		UpdatePositions();
	}
	
}
