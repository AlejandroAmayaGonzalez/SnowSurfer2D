using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float torqueAmount = 8f;
    [SerializeField] private float boostSpeed = 35f;
    
    SurfaceEffector2D surfaceEffector;
    float baseSpeed;

    InputAction moveAction;
    Vector2 moveInput;
    Rigidbody2D rb;

    void Start(){
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

        surfaceEffector = FindAnyObjectByType<SurfaceEffector2D>();
        baseSpeed = surfaceEffector.speed;
    }

    void Update(){
        PlayerTorque();
        BoostPlayer();
    }

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
            surfaceEffector.speed = boostSpeed;
        }else{
            surfaceEffector.speed = baseSpeed;
        }
    }
}
