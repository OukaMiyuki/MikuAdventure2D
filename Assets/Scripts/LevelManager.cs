using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    
    public static LevelManager instance;

    [SerializeField] private float waitToRespawn;
    public int gemsCollected;

    private void Awake() {
        instance = this;
    }

    void Start() {
        
    }


    void Update() {
        
    }

    public void RespawnPlayer() {
        StartCoroutine(RespawnCo());
    }

    private IEnumerator RespawnCo() {
        PlayerController.instance.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        PlayerController.instance.gameObject.SetActive(true);
        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }
}
