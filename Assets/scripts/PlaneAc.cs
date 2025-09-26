using UnityEngine;
using System.Collections;

public class PlaneAc : MonoBehaviour
{
    public GameObject plane; // Assign the plane GameObject in the inspector
    private Coroutine activateCoroutine;
    private Coroutine deactivateCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            if (deactivateCoroutine != null)
            {
                StopCoroutine(deactivateCoroutine);
            }
            activateCoroutine = StartCoroutine(ActivatePlaneAfterDelay(1f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit: " + other.gameObject.name);
        if (other.CompareTag("Player"))
        {
            if (activateCoroutine != null)
            {
                StopCoroutine(activateCoroutine);
            }
            deactivateCoroutine = StartCoroutine(DeactivatePlaneAfterDelay(1f));
        }
    }

    IEnumerator ActivatePlaneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Activating Plane");
        plane.SetActive(true);
    }

    IEnumerator DeactivatePlaneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("Deactivating Plane");
        plane.SetActive(false);
    }
}

