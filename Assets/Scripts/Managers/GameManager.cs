using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string ACT_1_TEXT = "La bolsa perdida";

    [SerializeField] private UIManager ui;
    [SerializeField] private FoxGameplay fox;
    [SerializeField] private KillBox killBox;

    [SerializeField] private PlatformsPerRow[] tutorialRows;
    [SerializeField] private PlatformsPerRow[] firstLevelRows;

    private int currentAct;
    private int maxPlatformRow;

    private void Awake()
    {
        currentAct = 1;
        maxPlatformRow = 0;

        rootbehavior.OnPlatform += CheckRows;
    }

    private void Start()
    {
        ui.SetTitlePanel(currentAct, ACT_1_TEXT, Color.black);
    }

    private void CheckRows(Transform platform) 
    {
        for(int i = 0; i < tutorialRows.Length; i++)
        {
            if (tutorialRows[i].platforms.Contains(platform))
            {
                if (i > maxPlatformRow + 1)
                {
                    fox.Die();
                    killBox.OnDelayedReset();
                }
                else maxPlatformRow++;
            }
        }
    }
}

[Serializable]
public struct PlatformsPerRow
{
    public List<Transform> platforms;
}