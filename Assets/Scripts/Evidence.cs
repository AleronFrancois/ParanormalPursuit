using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    public int value;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            EvidenceCounter.instance.IncreaseEvidence(value);
        }
    }
}
