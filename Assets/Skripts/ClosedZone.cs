using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedZone : MonoBehaviour
{
    public Text ClosedText;

    private void OnTriggerEnter(Collider other)
    {
        ClosedText.gameObject.SetActive(true); 
    }
    private void OnTriggerExit(Collider other)
    {
        ClosedText.gameObject.SetActive(false);
    }
}
