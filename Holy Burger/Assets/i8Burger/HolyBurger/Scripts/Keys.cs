using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour,IReseatable
{
    public bool isUsed;
    public ingredients Typeingredients;

    void Start()
    {
        AddToList();
    }

    public void OnTake()
    {
        
        gameObject.SetActive(false); 
    }

    public void ResetObjects()
    {
        isUsed = false;
    }

    public void AddToList()
    {
        GameController.Instance.resetableObjects.Add(this);
    }
}

public enum ingredients
{
Lettuce,
tomatos,
Cheese,
Bons,
Meat
}