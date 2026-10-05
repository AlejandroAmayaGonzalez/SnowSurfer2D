using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float torqueAmount = 8f;
    [SerializeField] private float boostSpeed = 35f;
    [SerializeField] ParticleSystem boostEffect;
    
    SurfaceEffector2D surfaceEffector;
    float baseSpeed;

    InputAction moveAction;
    Vector2 moveInput;
    Rigidbody2D rb;

    void Start(){
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();

        surfaceEffector = FindAnyObjectByType<SurfaceEffector2D>();
        baseSpeed = surfaceEffector.speed; // Store the base speed of the surface effector
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
            boostEffect.Play();
            surfaceEffector.speed = boostSpeed;
        }else{
            //boostEffect.Stop();
            surfaceEffector.speed = baseSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        
        int layerIndex = LayerMask.NameToLayer("Ground");
        if (collision.gameObject.layer == layerIndex){
            boostEffect.Play();
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        int layerIndex = LayerMask.NameToLayer("Ground");
        if (collision.gameObject.layer == layerIndex){
            boostEffect.Stop();
        }
    }
}
