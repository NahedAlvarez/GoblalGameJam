using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransform : MonoBehaviour
{
	public Transform target;
	
	public bool rotation = false;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
	void Update()
	{
		if(target == null)
			return;
    	
		this.transform.position = target.transform.position;
		
		if(rotation)
			this.transform.rotation = target.transform.rotation;
    }
}
