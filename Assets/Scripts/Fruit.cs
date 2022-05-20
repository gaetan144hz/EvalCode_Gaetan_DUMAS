using System;
using UnityEngine;

public class Fruit : MonoBehaviour
{

    private Spawner spawner;

    private void Start()
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SnakeController>())
        {
            
        }
    }
}
