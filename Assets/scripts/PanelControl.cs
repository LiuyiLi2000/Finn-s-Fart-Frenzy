using UnityEngine;

public class PanelControl : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4; // The panels you want to monitor
    public Fart1 fart1Script;

    void Update()
    {
        if (panel1.activeSelf || panel2.activeSelf || panel3.activeSelf || panel4.activeSelf)
        {
            ResetExplosionRangeIfNeeded();
        }
    }

    private void ResetExplosionRangeIfNeeded()
    {
        if (fart1Script.GetExplosionRange() != 2f)
        {
            fart1Script.ResetExplosionRange();
        }
    }
}


