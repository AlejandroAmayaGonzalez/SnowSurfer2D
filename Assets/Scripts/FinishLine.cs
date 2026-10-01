using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

    [SerializeField] private float reloadDelay = 1f;
    [SerializeField] private ParticleSystem finishEffect;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            finishEffect.Play();
            Debug.Log("Finished!");

            // Delay the scene reload by 1 seconds calling the method
            Invoke(nameof(ReloadScene), reloadDelay);
        }
    }

    void ReloadScene(){
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
