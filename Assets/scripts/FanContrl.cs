using UnityEngine;

public class FanContrl : MonoBehaviour
{
    public GameObject objectToDeactivate;
    public GameObject objectToActivate;

    public void Toggle()
    {
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
