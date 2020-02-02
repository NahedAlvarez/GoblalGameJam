using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightIntensity : MonoBehaviour
{
	Light light;
	public float speed = 1;
	float targetIntensity = 0;
	
    // Start is called before the first frame update
    void Start()
    {
	    light = this.GetComponent<Light>();
	    
	    targetIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
	    if(light.intensity < targetIntensity)
	    {
	    	light.intensity += Time.deltaTime*speed;
	    	
	    	if(light.intensity > targetIntensity)
		    	light.intensity = targetIntensity;
	    	
	    }else if(light.intensity > targetIntensity)
	    {
	    	light.intensity -= Time.deltaTime*speed;
	    	
	    	if(light.intensity < targetIntensity)
		    	light.intensity = targetIntensity;
	    	
	    }
    }
    
	public void SetTargetIntensity(float target)
	{
		targetIntensity = target;
	}
	
}
