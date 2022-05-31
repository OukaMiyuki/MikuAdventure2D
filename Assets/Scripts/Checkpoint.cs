using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static Checkpoint instance;

    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private Sprite cpOn, cpOff;
    
    private void Awake(){
        instance = this;
    }

    void Start() {
        
    }


    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player")){
            CheckpointController.instance.DeactivateCheckpoint();
            SR.sprite = cpOn;
            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckpoint(){
        SR.sprite = cpOff;
    }
}
