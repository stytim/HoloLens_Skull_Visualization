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
    public class Transform : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            GameObject menu = GameObject.Find("Menu");
            GameObject Temp = GameObject.Find("TempMenu");
                      
                menu.SetActive(false);
            Temp.SetActive(true);

                
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}