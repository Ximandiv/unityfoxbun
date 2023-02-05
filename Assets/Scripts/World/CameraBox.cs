using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraBox : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera newCamera;
    [SerializeField] private CinemachineVirtualCamera currentCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            newCamera.Priority = 20;
            currentCamera.Priority = 10;
        }
    }
}
