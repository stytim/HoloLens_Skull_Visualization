using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XLock : MonoBehaviour {
    private float LockY;
    private float lockZ;
   // Quaternion lockrot;
    // Use this for initialization
    void Start () {
       // lockrot.eulerAngles = new Vector3(0,0,0);
        LockY = 0f;
        lockZ = 186f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(transform.localPosition.x, LockY , lockZ);
       // transform.localRotation = lockrot;
    }
}
