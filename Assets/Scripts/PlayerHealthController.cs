using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour {

    public static PlayerHealthController instance;

    [SerializeField] public int currentHealth, maxHealth;
    [SerializeField] private float invincibleLength;

    private float invincibleCounter;
    private SpriteRenderer SR;

    private void Awake(){
        instance = this;
    }

    void Start() {
       currentHealth = maxHealth;
       SR = GetComponent<SpriteRenderer>(); 
    }

    void Update() {
        if(invincibleCounter > 0){
            invincibleCounter-=Time.deltaTime;
            if(invincibleCounter <= 0){
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, 1f);
            }
        }
    }

    public void DealDamage(){

        if(invincibleCounter <= 0){

            currentHealth -= 1;

            if(currentHealth <= 0){
                currentHealth = 0;
                //gameObject.SetActive(false);
                LevelManager.instance.RespawnPlayer();
            } else {
                invincibleCounter = invincibleLength;
                SR.color = new Color(SR.color.r, SR.color.g, SR.color.b, .5f);
                PlayerController.instance.konckBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
    }

    public void HealPlayer(){
        currentHealth+=1;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
