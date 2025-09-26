using UnityEngine;

public class Fart1 : MonoBehaviour
{
    public float ExplosionRange = 2f; // Initial explosion range
    public LayerMask WhatToDestroy;
    private float TimeToDetonate = 2f;

    private void Start()
    {
        Invoke("Detonate", TimeToDetonate);
    }

    void Detonate()
    {
        Debug.Log("Detonate function called!");

        Collider2D[] ObjectsToDestroy = Physics2D.OverlapCircleAll(transform.position, ExplosionRange, WhatToDestroy);
        for (int i = 0; i < ObjectsToDestroy.Length; i++)
        {
            Debug.Log("Detected: " + ObjectsToDestroy[i].name);
            RockControl boss = ObjectsToDestroy[i].GetComponent<RockControl>();
            if (boss != null)
            {
                boss.CustomDestroy();
            }
        }

        Destroy(gameObject);
    }

    // Method to double the explosion range
    public void SetExplosionRangeTo3_5()
    {
        ExplosionRange = 3.2f;
    }
     public void ResetExplosionRange()
    {
        ExplosionRange = 2f;
    }
     public float GetExplosionRange()
    {
        return ExplosionRange;
    }
}


