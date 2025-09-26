using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI1 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("UI0");
    }
}

