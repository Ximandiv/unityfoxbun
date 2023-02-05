using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
