using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBunny : MonoBehaviour
{
    public static Action OnReachedObjective;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnReachedObjective?.Invoke();
        }
    }
}
