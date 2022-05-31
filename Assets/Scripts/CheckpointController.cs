using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public static CheckpointController instance;

    [SerializeField] public Vector3 spawnPoint;

    private Checkpoint[] checkpoints;

    private void Awake() {
        instance = this;
    }

    void Start() {
        checkpoints = FindObjectsOfType<Checkpoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }


    void Update() {
        
    }

    public void DeactivateCheckpoint(){
        for(int i=0; i<checkpoints.Length; i++){
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(Vector3 newSpawnPoint){
        spawnPoint = newSpawnPoint;
    }
}
