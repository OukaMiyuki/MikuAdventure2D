using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

    void Start() {
        
    }


    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            LevelManager.instance.RespawnPlayer();
        }
    }
}
