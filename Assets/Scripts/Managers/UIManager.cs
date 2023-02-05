using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject winPanel, losePanel;
    //[SerializeField] private GameObject losePanel;

    [SerializeField] private TextMeshProUGUI actMesh;
    [SerializeField] private TextMeshProUGUI titleMesh;
    [SerializeField] private Image background;
    [SerializeField] new private Animator animator;

    private void SetAct(int act)
    {
        actMesh.text = string.Format("Acto {0}:", act);
    }

    private void SetTitle(string text)
    {
        titleMesh.text = text;
    }

    public void SetTitlePanel(int act, string text, Color color) 
    {
        SetAct(act);
        SetTitle(text);

        background.color = color;

        animator.enabled = true;
        animator.SetTrigger("Show");
    }
}
