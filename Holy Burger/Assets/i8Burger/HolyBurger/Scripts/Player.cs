using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IReseatable
{
    public List<Keys> obtainKeys = new List<Keys>();
    public Transform spawnPoint;

    private void Start()
    {
        AddToList();
        transform.position = spawnPoint.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Keys>())
        {
            collision.gameObject.GetComponent<Keys>().OnTake();
            obtainKeys.Add(collision.gameObject.GetComponent<Keys>());
        }
        if (collision.gameObject.GetComponent<Doors>())
        {
            for (int i = 0; i < obtainKeys.Count; i++)
            {
                collision.gameObject.GetComponent<Doors>().Open(obtainKeys[i]);
            }
          
        }
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
