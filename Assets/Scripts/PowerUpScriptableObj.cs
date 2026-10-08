using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "PowerUps/PowerUpData", order = 1)]
public class PowerUpScriptableObj : ScriptableObject {

    [SerializeField] private string powerUpType; // Speed, Health, Shield, etc.
    [SerializeField] private float timeLimit; // How long the power-up lasts
    [SerializeField] private float powerUpValue; // increase amount

    // Get and set
    public string PowerUpType { get => powerUpType; set => powerUpType = value; }
    public float TimeLimit { get => timeLimit; set => timeLimit = value; }
    public float PowerUpValue { get => powerUpValue; set => powerUpValue = value; }
}
