using UnityEngine;
using UnityEngine.UI;

public class IncreaseTimerButton : MonoBehaviour
{
    public timer1 timerScript; // Assign this in the Inspector

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(() => timerScript.IncreaseTimerAndRestart(20f)); // Add 20 seconds
    }
}


