using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other){
        int layerIndex = LayerMask.NameToLayer("Ground");

        if (other.gameObject.layer == layerIndex){
            Debug.Log("Crashed!");
        }

        Invoke(nameof(ReloadScene), 1f);
    }

    void ReloadScene(){
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
