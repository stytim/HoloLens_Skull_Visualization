using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClippingPlane : MonoBehaviour {
    GameObject bone;
    Renderer rend;
	// Use this for initialization
	void Start () {
        bone = GameObject.Find("bone");
        rend = bone.GetComponent<Renderer>();

	}
	
	// Update is called once per frame
	public void ClipX()
    {
      //  float planex = rend.material.GetVector("_PlanePoint").x;
        
        rend.material.SetVector("_PlaneNormal",new Vector4(0.1f,0f,0f,0f));
        rend.material.SetVector("_PlanePoint", new Vector4(-0.07f, 0f, 0f, 0f));
    }
    public void ClipY()
    {
        rend.material.SetVector("_PlaneNormal", new Vector4(0f, 0.1f, 0f, 0f));
        rend.material.SetVector("_PlanePoint", new Vector4(0f, 0f, 0f, 0f));
    }
    public void ClipZ()
    {
        rend.material.SetVector("_PlaneNormal", new Vector4(0f, 0f, 0.1f, 0f));
        rend.material.SetVector("_PlanePoint", new Vector4(0f, 0f, -0.08f, 0f));
    }
}
