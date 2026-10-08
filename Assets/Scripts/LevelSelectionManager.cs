using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionManager : MonoBehaviour {
    public void LevelSelection(string levelName){
        switch (levelName){
            case "Level1":
                SceneManager.LoadScene(levelName);
                break;
            case "Level2":
                SceneManager.LoadScene(levelName);
                break;
            case "Level3":
                SceneManager.LoadScene(levelName);
                break;
            case "Level4":
                SceneManager.LoadScene(levelName);
                break;
            case "Level5":
                SceneManager.LoadScene(levelName);
                break;
            case "Level6":
                SceneManager.LoadScene(levelName);
                break;
            case "Menu":
                SceneManager.LoadScene(levelName);
                break;    
            default:
                Debug.LogError("Invalid level selection: " + gameObject.name);
                break;
        }
    }
}
