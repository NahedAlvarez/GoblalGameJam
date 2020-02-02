using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnTriggerEnter : MonoBehaviour
{
	public List<GameObject> targets= new List<GameObject>();
	public LayerMask layer;
	public UnityEvent onTriggerEnterEvent;
	public UnityEvent onTriggerExitEvent;
	
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	private void OnTriggerEnter(Collider other)
	{
		
		if((layer.value & 1<< other.gameObject.layer) != 0
			|| targets.Contains(other.gameObject))
		{
			//Debug.Log(other);
			onTriggerEnterEvent.Invoke();
		}
	}
    
	private void OnTriggerExit(Collider other)
	{
		
		if((layer.value & 1<< other.gameObject.layer) != 0
			|| targets.Contains(other.gameObject))
		{
			//Debug.Log(other);
			onTriggerExitEvent.Invoke();
		}
	}
	
	/*private void OnCollisionEnter(Collision col)
	{
		
		Debug.Log(col.gameObject.name);
		if((col.gameObject.layer == layer)
			|| targets.Contains(col.gameObject))
		{
			onTriggerEnterEvent.Invoke();
		}
	}*/
}
