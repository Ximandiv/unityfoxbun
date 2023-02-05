using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxGameplay : MonoBehaviour
{
    [SerializeField] private Transform spawnPivot;

    public void Die() 
    {
        transform.position = spawnPivot.position;
    }
}
