using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private GameObject message;

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            message.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player") 
        {
            message.SetActive(false);
        }
    }
}
