using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private float minHeight, maxHeight;
    [SerializeField] private float minDirX, maxDirY;
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minDirX, maxDirY), Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
    }
}
