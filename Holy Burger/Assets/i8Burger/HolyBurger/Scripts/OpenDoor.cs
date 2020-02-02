using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, IReseatable
{
	public float speed = 1;
	
	bool openning;
	Vector3 startPosition;
	
    // Start is called before the first frame update
    void Start()
    {
	    startPosition = this.transform.position;
	    AddToList();
    }

    // Update is called once per frame
    void Update()
    {
	    if(openning)
	    {
	    	
		    this.transform.position = this.transform.position+Vector3.down*speed*Time.deltaTime;
		    
		    if(this.transform.position.y < -20)
		    	openning = false;
	    }
    }
    
	public void Open()
	{
		openning = true;
	}

	public void ResetObjects()
	{
		openning = false;
		this.transform.position = startPosition;
	}

	public void AddToList()
	{
		GameController.Instance.resetableObjects.Add(this);
	}
}
