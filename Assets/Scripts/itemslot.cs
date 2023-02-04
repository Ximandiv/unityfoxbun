using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class itemslot : MonoBehaviour
{
    public Image emptySlot;
    public Sprite emptySlotSprite;
    public Sprite pickSlot1;
    public Sprite stolenSlot1;
    public items item;

    private void Awake()
    {
        ItemBehavior2.OnObjectPicked += SetImage;
        ItemBehavior2.OnObjectStolen += SetImageStolen;
        PlayerController.OnObjectDropped += SetImageOriginal;
    }
    private void SetImage()
    {
        print("Objeto recogido");
        emptySlot.sprite = pickSlot1;
    }
    private void SetImageStolen()
    {
        print("Objeto robado");
        emptySlot.sprite = stolenSlot1;
    }

    private void SetImageOriginal()
    {
        print("Dropped");
        emptySlot.sprite = emptySlotSprite;
    }
}
