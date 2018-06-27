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
    public class LoadModel : MonoBehaviour, IInputClickHandler
    {
        public void OnInputClicked(InputClickedEventData eventData)
        {
            GameObject bone = GameObject.Find("bone");
            if (this.gameObject.name == "Load")
            {
                Vector3 headpos = Camera.main.transform.position;
                Vector3 gazepos = Camera.main.transform.forward;
                bone.transform.position = headpos + gazepos * 0.8f;
                bone.SetActive(true);
                Quaternion temprot = new Quaternion();
                temprot.SetLookRotation(bone.transform.position, Vector3.back);
                bone.transform.rotation = temprot;
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}