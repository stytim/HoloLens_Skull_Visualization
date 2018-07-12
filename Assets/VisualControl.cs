using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualControl : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        ;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("skull"))
        {

            other.gameObject.GetComponent<MeshRenderer>().enabled = false;


        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("skull"))
        {

            other.gameObject.GetComponent<MeshRenderer>().enabled = true;

        }
    }
}
