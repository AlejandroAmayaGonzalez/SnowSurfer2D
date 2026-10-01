using UnityEngine;

public class CrashDetector : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other){
        int layerIndex = LayerMask.NameToLayer("Ground");

        if (other.gameObject.layer == layerIndex){
            Debug.Log("Crashed!");
        }
    }
}
