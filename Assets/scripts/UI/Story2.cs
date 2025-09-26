using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Story2: MonoBehaviour
{
    public GameObject St2;
    public GameObject St1; 

    public void Play2()
    {
        St2.SetActive(true);
        St1.SetActive(false);
    }
}

