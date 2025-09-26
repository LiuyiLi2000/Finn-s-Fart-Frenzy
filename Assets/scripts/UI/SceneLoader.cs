using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private TextMeshProUGUI loadingText;
    [SerializeField] private float minimumLoadingTime = 5f; // Minimum time to show the loading screen

    private void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    private IEnumerator LoadSceneAsync()
    {
        float startTime = Time.time;
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false; // Prevents the scene from activating immediately after loading

        // Update the progress bar while loading
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingText.text = $"Loading... {progress * 100}%";

            // Check if loading is complete and the minimum time has passed
            if (asyncLoad.progress >= 0.9f && Time.time - startTime >= minimumLoadingTime)
            {
                asyncLoad.allowSceneActivation = true; // Allow the scene to activate
            }

            yield return null;
        }
    }
}
