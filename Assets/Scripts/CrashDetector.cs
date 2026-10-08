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

        if (other.CompareTag("Ground") && playerController.CanControlPlayer){
            playerController.CanControlPlayer = false; // Disable player control
            crashEffect.Play();
            Invoke(nameof(ReloadScene), crashDelay);
        }

        if (other.CompareTag("FinishLine") && playerController.CanControlPlayer){
            playerController.CanControlPlayer = false; // Disable player control
            Invoke(nameof(ReloadScene), crashDelay);
        }
    }

    void ReloadScene(){
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
