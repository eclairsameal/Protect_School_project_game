using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Data;

public class CMySql : MonoBehaviour
{
    
    private Text t = null;

    private void Start()
    {
        t.text = "aaa\n";
    }
    // On quit    
    public  void OnApplicationQuit()
    {
        t.text = "aaa\n";
    }


    // Disconnect from database    
  
    
}