using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Debug.Log("Finsihed!");
        }

        // Delay the scene reload by 1 seconds calling the method
        Invoke(nameof(ReloadScene), 1f); 
    }

    void ReloadScene(){
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
