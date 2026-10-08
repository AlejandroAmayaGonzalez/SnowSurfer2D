using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour {
    [SerializeField] TextMeshProUGUI scoreText; // Reference to the TextMesh component for displaying the score

    public void AddScore(int score){
        // Update the score text with the new score
        scoreText.text = score.ToString("00000");
    }
    
}
