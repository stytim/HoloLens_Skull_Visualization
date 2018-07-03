using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class DecreaseAlpha : MonoBehaviour, IInputClickHandler
    {
        Renderer rend;
        Renderer layerrend;
        public Material[] materiallist;
        // public GameObject[] bonelayers;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            GameObject bone = GameObject.Find("bone");
            GameObject[] bonelayers;
            bonelayers = GameObject.FindGameObjectsWithTag("skull");
            rend = bone.GetComponent<Renderer>();
            if (this.gameObject.name == "AlphaMinus")
            {
                if (bone.activeSelf)
                {
                    if (rend.material.name == "UIDarkSkull (Instance)")
                    {
                        rend.material = materiallist[0];
                    }               
                    Color color = rend.material.color;
                    color.a -= 0.1f * color.a;
                    rend.material.color = color;
                }
                else
                {
                    Debug.Log(bonelayers.Length);
                    foreach (GameObject bones in bonelayers)
                    {
                        
                        layerrend = bones.GetComponent<Renderer>();
                        if (layerrend.material.name == "UIDarkSkull (Instance)")
                        {
                            layerrend.material = materiallist[0];
                        }
                        
                        Color color = layerrend.material.color;
                        color.a -= 0.1f * color.a;
                        layerrend.material.color = color;

                    }
                   
                }
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}