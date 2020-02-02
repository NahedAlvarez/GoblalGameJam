using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IReseatable
{
    public Transform spawnPoint;

    private void Start()
    {
        AddToList();
        transform.position = spawnPoint.position;
    }
    

    public void ResetObjects()
    {
        transform.position = spawnPoint.position;       
    }

    public void AddToList()
    {
        GameController.Instance.resetableObjects.Add(this);
    }

}
