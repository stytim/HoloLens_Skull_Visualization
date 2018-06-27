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
    public class MaxAlpha : MonoBehaviour, IInputClickHandler
    {
        Renderer rend;
        public Material[] materiallist;
        public GameObject[] bonelayers;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            GameObject bone = GameObject.Find("bone");
            GameObject skull = GameObject.Find("skull");
            rend = bone.GetComponent<Renderer>();
            if (this.gameObject.name == "AlphaMax")
            {

                if (bone.activeSelf)
                {
                    rend.material = materiallist[0];
                }
                else
                {
                    foreach (GameObject bones in bonelayers)
                    {
                        Renderer layerrend;
                        layerrend = bones.GetComponent<Renderer>();
                        layerrend.material = materiallist[0];
                        Color color = layerrend.material.color;
                        color.a = 0f;
                        layerrend.material.color = color;

                    }
                }
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}