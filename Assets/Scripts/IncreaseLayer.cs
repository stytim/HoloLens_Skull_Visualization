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
    public class IncreaseLayer : MonoBehaviour, IInputClickHandler
    {
        public GameObject[] bonelayers;
        GameObject bone;
        GameObject skull;
        void Start()
        {
            bone = GameObject.Find("bone");
            skull = GameObject.Find("skull");
        }
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            if (this.gameObject.name == "LayerPlus")
            {
                foreach (GameObject bones in bonelayers)
                {
                    int index = Array.IndexOf(bonelayers, bones);
                    if (index == 16)
                    {
                        UnityEngine.Transform trans = skull.transform;
                        bone.transform.localPosition = trans.localPosition;
                        bone.transform.localRotation = trans.localRotation;
                        bone.transform.localScale = trans.localScale;
                       
                         Renderer bonerend = bone.GetComponent<Renderer>();
                         bonerend.material = bones.GetComponent<Renderer>().material;
                        
                        bone.GetComponent<MeshRenderer>().enabled =true;
                        foreach (GameObject boness in bonelayers)
                        {
                            boness.GetComponent<MeshRenderer>().enabled = false;
                        }
                            //skull.SetActive(false);
                            break;
                    }
                    else
                    {
                        if (!bones.GetComponent<MeshRenderer>().enabled)
                        {
                            bones.GetComponent<MeshRenderer>().enabled = true;
                            break;
                        }
                    }

                }                           
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}