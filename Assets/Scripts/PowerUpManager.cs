using System;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    
    [SerializeField] private PowerUpScriptableObj powerUpData; // Reference to the PowerUpScriptableObj

    PlayerController playerController; // Reference to the PlayerController script
    SpriteRenderer giftBagSpriteRenderer; // Reference to the SpriteRenderer for the gift bag

    float timeLeft; // Time left for the power-up effect

    private void Start() {
        playerController = FindAnyObjectByType<PlayerController>(); 
        giftBagSpriteRenderer = GetComponentInChildren<SpriteRenderer>(); 
        timeLeft = powerUpData.TimeLimit; 
    }

    private void Update() {
        CountDownPowerUp();
    }

    private void CountDownPowerUp(){
        if (giftBagSpriteRenderer.enabled == false){
            if (timeLeft > 0){
                timeLeft -= Time.deltaTime; // Decrease the time left by the time elapsed since the last frame
                if (timeLeft <= 0){
                    playerController.RemovePowerUp(powerUpData);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && giftBagSpriteRenderer.enabled) {
            giftBagSpriteRenderer.enabled = false; // Hide the gift bag sprite
            playerController.ApplyPowerUp(powerUpData); // Apply the power-up effect to the player
        }
    }
}
