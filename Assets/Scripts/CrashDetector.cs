using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour {

    [SerializeField] private float crashDelay = 2f;
    [SerializeField] private ParticleSystem crashEffect;

    void OnTriggerEnter2D(Collider2D other){
        int layerIndex = LayerMask.NameToLayer("Ground");

        if (other.gameObject.layer == layerIndex){
            Debug.Log("Crashed!");
            crashEffect.Play();
        }

        Invoke(nameof(ReloadScene), crashDelay);
    }

    void ReloadScene(){
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
