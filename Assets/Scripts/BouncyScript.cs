using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyScript : MonoBehaviour {

    [SerializeField] private float force = 500f;
    private Animator anim;

    private void Awake(){
        anim = GetComponent<Animator>();
    }
    
    void Start() {
        
    }

    IEnumerator AnimateBouncy(){
        anim.Play("BouncerUp");
        yield return new WaitForSeconds(.5f);
        anim.Play("BouncerDown");
    }

    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "Player"){
            col.gameObject.GetComponent<PlayerController>().BouncePlayer(force);
            StartCoroutine(AnimateBouncy());
        }
    }
}
