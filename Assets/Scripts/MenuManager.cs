using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    public void PlayGame(){
        SceneManager.LoadScene("SelectLevel");
    }

    public void Characters(){
        SceneManager.LoadScene("SelectChar");
    }

    public void SeeCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame(){
        // Quit the application when the quit button is clicked
        Application.Quit();
    }

    public void SelectChar(int characterIndex){
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        PlayerPrefs.Save(); // Save the selected character index to PlayerPrefs

        SceneManager.LoadScene("Menu");
    }
}
