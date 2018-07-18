using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour {
    GameObject bone;
    GameObject plane;
   // GameObject skull;
   //GameObject[] bonelayers;
    public Material[] materiallist;
    // Use this for initialization
    void Start () {
        bone = GameObject.Find("bone");
        plane = GameObject.Find("X-plane");
      //  skull = GameObject.Find("skull");
      //  bonelayers = GameObject.FindGameObjectsWithTag("skull");
    }
	
    public void Loadmodel()
    {
        Vector3 headpos = Camera.main.transform.position;
        Vector3 gazepos = Camera.main.transform.forward;
        bone.transform.position = headpos + gazepos * 0.8f;
        bone.GetComponent<MeshRenderer>().enabled = true;
        Quaternion temprot = new Quaternion();
        temprot.SetLookRotation(bone.transform.position, Vector3.back);
        bone.transform.rotation = temprot;
        bone.transform.eulerAngles = new Vector3(bone.transform.eulerAngles.x - 90, bone.transform.eulerAngles.y, bone.transform.eulerAngles.z);
    }

    public void Sizeplus()
    {
        bone.transform.localScale += 0.03f * bone.transform.localScale;
    }
    public void Sizeminus()
    {
        bone.transform.localScale -= 0.03f * bone.transform.localScale;
    }
    public void Alphaplus()
    {

    }
    public void Alphaminus()
    {

    }
    public void AlphaMax()
    {

    }
    public void AlphaMin()
    {

    }
    public void LayerPlus()
    {

    }
    public void LayerMinus()
    {

    }
   
}
