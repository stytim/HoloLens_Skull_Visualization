using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visual : MonoBehaviour {

   // private Rigidbody rb1;
    Renderer rend;
    Renderer rend1;
    Color temp;

    // Use this for initialization
    void Start()
    {
      //  rb1 = GetComponent<Rigidbody>();
        rend = GetComponent<Renderer>();
        GameObject bat = GameObject.Find("bone");
        rend1 = bat.GetComponent<Renderer>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bone"))
        {
            Color color = rend.material.color;
            Color color1 = rend1.material.color;
            temp = color1;
            
            if (color1.a > 0.4f)
            {
                color.a = 0.5f;
                color1.a = 0.4f;
                rend1.material.color = color1;
            }
           

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bone"))
        {

            //  Color color1 = rend1.material.color;
            //  color1.a = 1f;
            Color color = rend.material.color;
            color.a = 1f;
            rend.material.color = color;
            rend1.material.color = temp;

        }
    }



}