using UnityEngine;

public class FinishLine : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D other) {
        int layerIndex = LayerMask.NameToLayer("FinishLine");

        if (other.gameObject.layer == layerIndex) {
            Debug.Log("Finish!!");
        }
    }
}
