using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBox : MonoBehaviour
{
    [SerializeField] private float newSize;
    [SerializeField] private Camera camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            camera.orthographicSize = newSize;
        }
    }
}
