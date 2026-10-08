using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

    [SerializeField] private float reloadDelay = 2f;
    [SerializeField] private ParticleSystem finishEffect;
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            finishEffect.Play();

            // Delay the scene reload by 1 seconds calling the method
            Invoke(nameof(NextLevel), reloadDelay);
        }
    }

    void NextLevel(){
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
        PlayerPrefs.Save();

        if (unlockedLevel > 4){
            SceneManager.LoadScene("Menu");
        }else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
