using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectionManager : MonoBehaviour {

    void Start(){
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        Transform levels = transform.GetChild(0);

        for (int i = 0; i < levels.childCount; i++){
            Button levelButton = levels.GetChild(i).GetComponent<Button>();
            levelButton.interactable = (i < unlockedLevel);
        }
    }

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
