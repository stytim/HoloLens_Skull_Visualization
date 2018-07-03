using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;

using System;

public partial class handTracker : Singleton<handTracker>
{

    public GameObject TrackingObject;
  ///  public GameObject TempMenu;
    public bool allowTrack = false;
    public bool enableHoldFunction = true;
    public GameObject handednessOffsetObj;
    private Vector3 rightHandLocalPos;

    private UnityEngine.XR.WSA.Input.GestureRecognizer recognizer;
    protected override void Awake()
    {
        base.Awake();
        UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceDetected += InteractionManager_SourceDetected;
        UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceLost += InteractionManager_SourceLost;
        UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceUpdated += InteractionManager_SourceUpdated;

        recognizer = new UnityEngine.XR.WSA.Input.GestureRecognizer();
        recognizer.SetRecognizableGestures(UnityEngine.XR.WSA.Input.GestureSettings.Hold);
        recognizer.HoldStartedEvent += SwitchAllowTrack;
        recognizer.StartCapturingGestures();

        if (handednessOffsetObj != null)
        {
            rightHandLocalPos = handednessOffsetObj.transform.localPosition;
        }
    }


    private void SwitchAllowTrack(UnityEngine.XR.WSA.Input.InteractionSourceKind source, Ray headRay)
    {
        if (enableHoldFunction)
        {
            allowTrack = !allowTrack;
            TrackingObject.SetActive(allowTrack);
        }
    }

    private void InteractionManager_SourceUpdated(UnityEngine.XR.WSA.Input.InteractionSourceUpdatedEventArgs args)
    {
        uint id = args.state.source.id;
        Debug.Log(id);
        Vector3 pos;

        if (args.state.source.kind == UnityEngine.XR.WSA.Input.InteractionSourceKind.Hand && allowTrack)
        {

            if (args.state.sourcePose.TryGetPosition(out pos))
            {
                Vector3 temppos = new Vector3(pos.x, pos.y, pos.z+0.05f);
          //      if (!TempMenu.activeSelf)
           //     {
                    TrackingObject.transform.position = Vector3.Lerp(TrackingObject.transform.position, temppos, 0.35f);
          //      }
           //     else
           //     {
          //          TempMenu.transform.position = Vector3.Lerp(TrackingObject.transform.position, temppos, 0.35f);
           //     }
                
            }

        }
    }

    private void InteractionManager_SourceDetected(UnityEngine.XR.WSA.Input.InteractionSourceDetectedEventArgs args)
    {
        // Check to see that the source is a hand.
        if (args.state.source.kind != UnityEngine.XR.WSA.Input.InteractionSourceKind.Hand)
        {
            return;
        }

        Vector3 pos;
        if (args.state.sourcePose.TryGetPosition(out pos) && allowTrack)
        {
            if (handednessOffsetObj != null)
            {
                bool isRightHand = Camera.main.worldToCameraMatrix.MultiplyPoint(pos).x > 0;
                handednessOffsetObj.transform.localPosition = isRightHand ? rightHandLocalPos : new Vector3(-rightHandLocalPos.x, rightHandLocalPos.y, rightHandLocalPos.z);
            }
            Vector3 temppos = new Vector3(pos.x, pos.y, pos.z + 0.05f);
         //   if (!TempMenu.activeSelf)
          //  {
                TrackingObject.SetActive(true);
                TrackingObject.transform.position = temppos;
           // }
          //  else
          //  {
         //       TempMenu.SetActive(true);
         //       TempMenu.transform.position = temppos;
         //   }
        }
            
           

    }

    private void InteractionManager_SourceLost(UnityEngine.XR.WSA.Input.InteractionSourceLostEventArgs args)
    {
        // Check to see that the source is a hand.
        if (args.state.source.kind != UnityEngine.XR.WSA.Input.InteractionSourceKind.Hand)
        {
            return;
        }

      //  TrackingObject.SetActive(false);
    }

    protected override void OnDestroy()
    {
        UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceDetected -= InteractionManager_SourceDetected;
        UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceLost -= InteractionManager_SourceLost;
        UnityEngine.XR.WSA.Input.InteractionManager.InteractionSourceUpdated -= InteractionManager_SourceUpdated;
    }
}
