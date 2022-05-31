using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

    [SerializeField] private float lifeTime;
   
    void Start() {
         
    }


    void Update() {
        lifeTime -= Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }
}
