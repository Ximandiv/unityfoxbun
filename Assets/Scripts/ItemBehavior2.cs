using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemBehavior2 : MonoBehaviour
{
    public static Action OnObjectPicked;
    public static Action OnObjectStolen;
    public PlayerController PlayerController;
    public items wea;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (PlayerController.isFull == false)
        {
            if (collider.tag == "Player" && PlayerController.dashing)
            {
                OnObjectStolen();
                Destroy(gameObject);
                PlayerController.isFull = true;
            }
        }
        else
        {
            print("Slot full!");
        }

    }
}
