using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController instance = null;
    // Game Instance Singleton
    public static GameController Instance
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
    #endregion

    public List<IReseatable> resetableObjects = new List<IReseatable>();
    int numReset;

    private void Start()
    {
        numReset = 4;    
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
            Debug.Log("Hola Entre a reset de GameController y voy a resetear a" + resetableObjects.Count);
        }
        if (numReset == 0)
        {
            Debug.Log("GameOver");
        }

    }
    private void Reset()
    {
        numReset--;
        foreach (IReseatable r in resetableObjects)
        {
            r.ResetObjects();
        }
    }
}
