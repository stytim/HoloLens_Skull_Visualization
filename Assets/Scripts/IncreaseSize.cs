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
    public class IncreaseSize : MonoBehaviour, IInputClickHandler
    {

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            GameObject bone = GameObject.Find("bone");
            GameObject skull = GameObject.Find("skull");
            if (this.gameObject.name == "SizePlus")
            {
                if (bone.activeSelf)
                {
                       bone.transform.localScale += 0.03f * bone.transform.localScale;
                }
                else
                {
                    skull.transform.localScale += 0.03f * skull.transform.localScale;
                }
                
            }
            
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}