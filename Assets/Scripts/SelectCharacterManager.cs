using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacterManager : MonoBehaviour {
    public void SelectCharacter(string characterName){
        switch (characterName){
            case "Frog":
                SceneManager.LoadScene("Menu");
                break;
            case "Dino":
                SceneManager.LoadScene("Menu");
                break;
            case "Back":
                SceneManager.LoadScene("Menu");
                break;
            default:
                Debug.LogError("Invalid character selection: " + gameObject.name);
                break;
        }
    }
}
