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
    public class ShiftLeft : MonoBehaviour, IInputClickHandler
    
    {
        public bool rotate;
      
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            GameObject movebutton = GameObject.Find("Move");
            GameObject bone = GameObject.Find("bone");
            if (this.gameObject.name == "Rotate")
            {
                bone.GetComponent<HandDraggable>().enabled = false;
              
                rotate = true;
                movebutton.GetComponent<ShiftRight>().move = false;
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}