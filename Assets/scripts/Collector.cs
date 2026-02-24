using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")|| other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }      
}
