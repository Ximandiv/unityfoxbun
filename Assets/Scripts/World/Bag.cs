using System;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public static Action OnGotKey;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnGotKey?.Invoke();

            gameObject.SetActive(false);
        }
    }
}
