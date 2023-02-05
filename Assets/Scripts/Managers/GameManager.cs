using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlatformsPerRow[] tutorialRows;
    [SerializeField] private PlatformsPerRow[] firstLevelRows;


}

[Serializable]
public struct PlatformsPerRow
{
    public Transform[] platforms;
}