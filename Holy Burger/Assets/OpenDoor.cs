using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
	public float speed = 1;
	
	bool openning;
	
    // Start is called before the first frame update
    void Start()
    {
        
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
}
