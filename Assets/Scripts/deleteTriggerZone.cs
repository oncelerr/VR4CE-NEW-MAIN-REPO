using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteTriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("dupedWater"))
        {
            Destroy(other.gameObject);
        }
    }
}
