using UnityEngine;
using UnityEngine.UI;

public class Bean : MonoBehaviour
{
    public AreaDi areaDiScript; // Assign the AreaDi script in the Inspector

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(areaDiScript.DoubleAreaSize);
    }
}


