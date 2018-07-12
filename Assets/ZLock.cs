using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZLock : MonoBehaviour
{
    private float LockX;
    private float lockY;
    // Quaternion lockrot;
    // Use this for initialization
    void Start()
    {
        // lockrot.eulerAngles = new Vector3(0,0,0);
        LockX = 0f;
        lockY = 195f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(LockX, transform.localPosition.y, lockY);
        // transform.localRotation = lockrot;
    }
}
