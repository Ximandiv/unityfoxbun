using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformsPerRow[] platformRows;


}

[Serializable]
public struct PlatformsPerRow
{
    public Transform[] platforms;
}