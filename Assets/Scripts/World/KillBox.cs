using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    [SerializeField] private float timeToReset;

    private void Awake()
    {
        rootbehavior.OnKilled += OnDelayedReset;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            OnDelayedReset();
        }
    }

    private void OnDestroy()
    {
        rootbehavior.OnKilled -= OnDelayedReset;
    }

    private void OnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnDelayedReset() 
    {
        Invoke(nameof(OnReset), timeToReset);
    }
}
