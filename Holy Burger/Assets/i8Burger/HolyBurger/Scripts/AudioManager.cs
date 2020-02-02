using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public AudioSource source;
	public List <AudioClip> allClips = new List<AudioClip>();
	
	private static AudioManager instance = null;
	// Game Instance Singleton
	public static AudioManager Instance
	{
		get
		{
			return instance;
		}
	}

	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
		}
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	
 
	
	
	void Start()
	{
		source = GetComponent<AudioSource>();
	}
	
	public void SelectAudio(string name)
	{
		source.PlayOneShot(AudioClipsName(name));
	}	
	
	AudioClip AudioClipsName(string name)
	{		
		foreach(AudioClip aud in allClips)
		{
			if(aud.name == name)
				return aud;
		}
		return null;
	}
}
