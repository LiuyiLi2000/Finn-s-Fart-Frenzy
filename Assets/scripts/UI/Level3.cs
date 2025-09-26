using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3 : MonoBehaviour
{
   public void PlayGame()
{
    StartCoroutine(PlayGameRoutine());
}

private IEnumerator PlayGameRoutine()
{
    yield return null;  // Wait for the next frame
    Time.timeScale = 1f;
    SceneManager.LoadScene("Level3");
}
}