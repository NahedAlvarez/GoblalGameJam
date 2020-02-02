using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burger : MonoBehaviour
{
	
	public List<GameObject> ingredients = new List<GameObject>();
	public GameObject BunTop, BunBottom;
	public float sizeOfIngredients = 0.1f;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	 
    
	private void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.layer == 8)
		{
			//its already in the burger
			if(ingredients.Contains(col.gameObject))
				return;
			
			//move here
			col.transform.SetParent(this.transform);
			
			//turn on kinematic rigidboard
			col.GetComponent<Rigidbody>().isKinematic = false;
			
			//resetposition
			col.transform.localPosition = Vector3.zero + Vector3.up*sizeOfIngredients * ingredients.Count; 
			
			ingredients.Add(col.gameObject);
		
			//make bun bigger - TO DO
			BunTop.transform.localPosition = Vector3.zero + Vector3.up*sizeOfIngredients * ingredients.Count;
		}
	}
	
}
