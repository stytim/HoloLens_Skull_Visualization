using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using System;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class MenuController : MonoBehaviour, IInputClickHandler
    {
        public Text Menutext;
  
        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.

            if (this.gameObject.name == "FixMenu")
            {
                GameObject Menu = GameObject.Find("Menu");
                
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
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.   
        }
    }
}