using UnityEngine;
using UnityEngine.SceneManagement;

public class SCR_SceneSwitcher : MonoBehaviour{
    //SINGLETON START
    public static SCR_SceneSwitcher Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
        //Persistency
        DontDestroyOnLoad(this.gameObject);
    }
    //SINGLETON END

    public void LoadMenu(){
        SceneManager.LoadScene("Menu");
    }

    public void LoadGame(){
        SceneManager.LoadScene("Game");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Tried to Quit (you're probably in editor)");
    }
}
