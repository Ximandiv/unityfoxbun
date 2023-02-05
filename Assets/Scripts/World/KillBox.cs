using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class KillBox : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera foxCam;
    [SerializeField] private CinemachineVirtualCamera gameplayCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            //collision.GetComponent<FoxGameplay>().Die();

            //foxCam.Priority = 20;
            //gameplayCam.Priority = 10;
        }
    }
}
