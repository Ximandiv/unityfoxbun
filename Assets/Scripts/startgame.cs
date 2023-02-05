using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class startgame : MonoBehaviour
{
    
    public void OnMouseDown(int ID)
    {
        SceneManager.LoadScene(ID);
    }
}
