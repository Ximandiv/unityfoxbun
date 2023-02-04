using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class itemslot : MonoBehaviour
{
    private void Awake()
    {
        PlayerController.OnObjectPicked += SetImage;
    }
    private void SetImage()
    {
        print("hola");
    }
}
