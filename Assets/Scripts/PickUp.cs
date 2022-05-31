using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    
    public static PickUp instance;

    [SerializeField] private bool isGem, isHeal;
    [SerializeField] private GameObject pickupEffect;
    private bool isCollected;

    private void Awake(){
        instance = this;
    }

    void Start() {
        
    }


    void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.CompareTag("Player") && !isCollected){
            if(isGem){
                LevelManager.instance.gemsCollected+=1;
                isCollected = true;
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);
                UIController.instance.UpdateGemCount();
            }

            if(isHeal){
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth){
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
