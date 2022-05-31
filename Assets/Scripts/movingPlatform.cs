using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatform : MonoBehaviour {

    [SerializeField] private Transform Position1, Position2;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float speed;
    
    private Vector3 nextPos;
    
    void Start() {
        nextPos = startPosition.position;
    }

    
    void Update() {
        if(transform.position == Position1.position){
            nextPos = Position2.position;
        }

        if(transform.position == Position2.position){
            nextPos = Position1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmoz(){
        Gizmos.DrawLine(Position1.position, Position2.position);
    }
}
