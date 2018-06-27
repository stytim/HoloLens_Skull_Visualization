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
    public class ShiftRight : MonoBehaviour, IInputClickHandler
    {
        public bool move;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.

            GameObject rotatebutton = GameObject.Find("Rotate");
            GameObject bone = GameObject.Find("bone");
            if (this.gameObject.name == "Move")
            {
                bone.GetComponent<HandDraggable>().enabled = true;
                move = true;
                rotatebutton.GetComponent<ShiftLeft>().rotate = false;
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}