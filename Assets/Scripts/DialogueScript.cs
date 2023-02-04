using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public SpriteRenderer rend;
    public GameObject place;
    public PlayerController PlayerController;

    public void Start()
    {
        rend = rend.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Player" && PlayerController.isDashing)
        {
            rend.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        rend.enabled = false;
    }
}
