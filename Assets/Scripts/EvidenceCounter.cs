using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EvidenceCounter : MonoBehaviour
{
    public static EvidenceCounter instance;

    public TMP_Text evidenceText;
    public int currentEvidence = 0;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        evidenceText.text = "Evidence Count: " + currentEvidence.ToString(); 
    }

    public void IncreaseEvidence(int v)
    {
        currentEvidence += v;
        evidenceText.text = "Evidence Count: " + currentEvidence.ToString();
    }
}
