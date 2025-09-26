using UnityEngine;
using UnityEngine.UI;

public class Banana: MonoBehaviour
{
    public FartControl fartControlScript; // Assign this in the Inspector
    public BossBefore bossBeforeScript; 

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(IncreaseFartTime);
    }

    void IncreaseFartTime()
    {
        fartControlScript.AutoFartTime = 65f;// Change the auto fart time to 65 seconds
         bossBeforeScript.UpdateAutoActivateTime(65f); 
    }
}

