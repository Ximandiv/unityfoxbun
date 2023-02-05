using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    private void Awake()
    {
        rootbehavior.OnKilled += OnReset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnReset();
        }
    }

    private void OnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
