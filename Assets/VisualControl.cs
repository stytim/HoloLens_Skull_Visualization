using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualControl : MonoBehaviour
{
    GameObject bone;
    GameObject skull;

    // Use this for initialization
    void Start()
    {
        bone = GameObject.Find("bone");
        skull = GameObject.Find("skull");
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("skull"))
        {

            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Transform trans = skull.transform;
            bone.transform.localPosition = trans.localPosition;
            bone.transform.localRotation = trans.localRotation;
            bone.transform.localScale = trans.localScale;

        }

        if (other.gameObject.CompareTag("bone"))
        {

            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            Transform trans = bone.transform;
            skull.transform.localPosition = trans.localPosition;
            skull.transform.localRotation = trans.localRotation;
            skull.transform.localScale = trans.localScale;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("skull"))
        {

            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
          //  Transform trans = skull.transform;
          //  bone.transform.localPosition = trans.localPosition;
          //  bone.transform.localRotation = trans.localRotation;
          //  bone.transform.localScale = trans.localScale;

        }
        if (other.gameObject.CompareTag("bone"))
        {

            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            Transform trans = skull.transform;
            other.transform.localPosition = trans.localPosition;
            other.transform.localRotation = trans.localRotation;
            other.transform.localScale = trans.localScale;

        }
    }
}
