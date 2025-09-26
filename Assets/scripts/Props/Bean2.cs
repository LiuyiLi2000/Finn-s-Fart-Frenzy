using UnityEngine;
using UnityEngine.UI;

public class Bean2 : MonoBehaviour
{
    public Fart1 fart1Script; // Assign the Fart1 script in the Inspector

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(fart1Script.SetExplosionRangeTo3_5);
    }
}


