using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float torqueAmount = 8f;
    [SerializeField] private float boostSpeed = 35f;
    [SerializeField] ParticleSystem boostEffect;
    [SerializeField] ParticleSystem snowEffect;
    [SerializeField] private ScoreManager scoreManager;
    
    private bool canControlPlayer = true; // Flag to control player input

    SurfaceEffector2D surfaceEffector;

    float baseSpeed;
    InputAction moveAction;
    Vector2 moveInput;
    Rigidbody2D rb;
    float previousRotation; // Previous rotation of the player
    float totalRotation; // Total rotation accumulated by the player
    int flipCount = 0; // Number of flips performed by the player

    void Start(){
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

        surfaceEffector = FindAnyObjectByType<SurfaceEffector2D>();
        baseSpeed = surfaceEffector.speed; // Store the base speed of the surface effector
    }

    void Update(){
        if (!canControlPlayer) return; // If player control is disabled, exit the method
        PlayerTorque();
        BoostPlayer();
        CalculateFlips();
    }

    // Get and set for the canControlPlayer flag
    public bool CanControlPlayer { get => canControlPlayer; set => canControlPlayer = value; }

    /// <summary>
    /// Applies torque to the player based on input from the Move action.
    /// </summary>
    void PlayerTorque(){
        moveInput = moveAction.ReadValue<Vector2>();

        if (moveInput.x < 0){
            rb.AddTorque(torqueAmount);
        }else{
            rb.AddTorque(-torqueAmount);
        }
    }

    /// <summary>
    /// Applies a boost to the player when the Boost action is triggered.
    /// </summary>
    void BoostPlayer(){
        // Increase player speeed when W is pressed
        // Surfer speed is increased
        if (moveInput.y > 0){
            boostEffect.Play();
            surfaceEffector.speed = boostSpeed;
        }else{
            //boostEffect.Stop();
            surfaceEffector.speed = baseSpeed;
        }
    }

    /// <summary>
    /// Calculates the number of flips the player has performed based on their rotation.
    /// </summary>
    private void CalculateFlips(){
        // Get the current rotation of the player in degrees
        float currentRotation = transform.rotation.eulerAngles.z;
        // Calculate the change in rotation since the last frame
        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation); 

        if (Math.Abs(totalRotation) >= 340f || totalRotation <= -340f){
            flipCount++;

            scoreManager.AddScore(flipCount * 100);

            totalRotation = 0f; // Reset the total rotation after a flip
        }

        previousRotation = currentRotation; // Update the previous rotation for the next frame
    }

    void OnCollisionEnter2D(Collision2D collision){
        int layerIndex = LayerMask.NameToLayer("Ground");

        if (collision.gameObject.layer == layerIndex){
            if (moveInput.y > 0){
                snowEffect.Play();
            }else if (!boostEffect.isPlaying){
                snowEffect.Stop();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        int layerIndex = LayerMask.NameToLayer("Ground");
        if (collision.gameObject.layer == layerIndex){
            snowEffect.Stop();
        }
    }
}
