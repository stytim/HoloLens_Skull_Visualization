using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
    GameObject bone;
    GameObject plane;
    GameObject Menu;
    GameObject part;
    public Text Menutext;
    public Material[] materallist;
    Renderer rend;
  
    // Use this for initialization
    void Start () {
        bone = GameObject.Find("bone");
        part = GameObject.Find("part");
        plane = GameObject.Find("X-plane");
        Menu = GameObject.Find("Menu");
        
    }
	
    public void Loadmodel()
    {
        Vector3 headpos = Camera.main.transform.position;
        Vector3 gazepos = Camera.main.transform.forward;
        bone.transform.position = headpos + gazepos * 0.8f;
        plane.transform.position = headpos + gazepos * 0.8f;
        Quaternion temprot = new Quaternion();
        Quaternion planerot = new Quaternion();
        planerot.SetLookRotation(plane.transform.position, Vector3.left);
        temprot.SetLookRotation(bone.transform.position, Vector3.back);
        bone.transform.rotation = temprot;
        plane.transform.rotation = planerot;
        bone.transform.eulerAngles = new Vector3(bone.transform.eulerAngles.x - 90, bone.transform.eulerAngles.y, bone.transform.eulerAngles.z);
        plane.transform.eulerAngles = new Vector3(plane.transform.eulerAngles.x + 90, plane.transform.eulerAngles.y, plane.transform.eulerAngles.z);
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
    public void Transparent()
    {
        rend = bone.GetComponent<Renderer>();
        Debug.Log(rend.material.name);
       // if (rend.material.name == "Transparent (Instance)") 
      //  {
      //      rend.material = materallist[1];
      //      Menutext.text = "Transparent!";
      //  }
        if (rend.material.name == "Opaque (Instance)")
        {
            rend.material = materallist[0];
            Menutext.text = "Opaque!";
        }
        else
        {
            rend.material = materallist[1];
            Menutext.text = "Transparent!";
        }
        
    }
    public void Highlight()
    {
        if (part.activeSelf)
        {
            part.SetActive(false);
        }
        else
        {
            part.SetActive(true);
        }
    }
   
}
