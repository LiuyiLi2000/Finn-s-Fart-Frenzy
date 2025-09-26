using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Story3: MonoBehaviour
{
   
    public GameObject St3; 
    public GameObject St2;

    public void Play3()
    {
        St3.SetActive(true);
        St2.SetActive(false);
    }
}

