﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class DecreaseLayer : MonoBehaviour, IInputClickHandler
    {
        public GameObject[] bonelayers;
        GameObject bone;
        GameObject skull;
        void Start()
        {
            bone = GameObject.Find("bone");
            skull = GameObject.Find("skull");
            bone.SetActive(true);
            skull.SetActive(false);
        }
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            if (this.gameObject.name == "LayerMinus")
            {
                // GameObject bone = GameObject.Find("bone");
                if (bone.activeSelf)
                {
                bone.SetActive(false);
                // GameObject skull = GameObject.Find("skull");
                UnityEngine.Transform trans= bone.transform;

                skull.SetActive(true);
                skull.transform.localPosition = trans.localPosition;
                skull.transform.localRotation = trans.localRotation;
                skull.transform.localScale = trans.localScale;
                foreach (GameObject bones in bonelayers)
                {
                    Renderer bonerend = bone.GetComponent<Renderer>();
                    bonerend.material = bone.GetComponent<Renderer>().material;
                }
                bonelayers[0].SetActive(false);

                }
                else
                {
                    foreach (GameObject bones in bonelayers)
                    {
                        if (bones.activeSelf)
                        {                                         
                            bones.SetActive(false);
                            break;
                        }
                    }           
                }       
            }
           
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}