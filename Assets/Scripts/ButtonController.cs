using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    GameObject bone;
    GameObject plane;
    GameObject Menu;
    public Text Menutext;
  
    // Use this for initialization
    void Start () {
        bone = GameObject.Find("bone");
        plane = GameObject.Find("X-plane");
        Menu = GameObject.Find("Menu");
    }
	
    public void Loadmodel()
    {
        Vector3 headpos = Camera.main.transform.position;
        Vector3 gazepos = Camera.main.transform.forward;
        bone.transform.position = headpos + gazepos * 0.8f;
        Quaternion temprot = new Quaternion();
        temprot.SetLookRotation(bone.transform.position, Vector3.back);
        bone.transform.rotation = temprot;
        bone.transform.eulerAngles = new Vector3(bone.transform.eulerAngles.x - 90, bone.transform.eulerAngles.y, bone.transform.eulerAngles.z);
    }

    public void Sizeplus()
    {
        bone.transform.localScale += 0.03f * bone.transform.localScale;
        plane.transform.localScale += 0.03f * plane.transform.localScale;
    }
    public void Sizeminus()
    {
        bone.transform.localScale -= 0.03f * bone.transform.localScale;
        plane.transform.localScale -= 0.03f * plane.transform.localScale;
    }
    public void FixMenu()
    {

        if (Menu.GetComponent<handTracker>().allowTrack)
        {
            Menu.GetComponent<handTracker>().allowTrack = false;
            Menutext.text = "Move Menu";
        }
        else
        {
            Menu.GetComponent<handTracker>().allowTrack = true;
            Menutext.text = "Fix Menu";
        }
    }
    
   
}
