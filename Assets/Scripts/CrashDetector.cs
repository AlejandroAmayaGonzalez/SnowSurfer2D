using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour {

    [SerializeField] private float crashDelay = 1.5f;
    [SerializeField] private ParticleSystem crashEffect;

    PlayerController playerController;

    void Start(){
        playerController = FindAnyObjectByType<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D other){
        int layerIndex = LayerMask.NameToLayer("Ground");

        if (other.gameObject.layer == layerIndex){
            playerController.CanControlPlayer = false; // Disable player control
            crashEffect.Play();
        }

        Invoke(nameof(ReloadScene), crashDelay);
    }

    void ReloadScene(){
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
