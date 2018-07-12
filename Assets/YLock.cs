using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLock : MonoBehaviour
{
    private float LockX;
    private float lockZ;
    // Quaternion lockrot;
    // Use this for initialization
    void Start()
    {
        // lockrot.eulerAngles = new Vector3(0,0,0);
        LockX = 0f;
        lockZ = -18f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(LockX, lockZ, transform.localPosition.z);
        // transform.localRotation = lockrot;
    }
}
