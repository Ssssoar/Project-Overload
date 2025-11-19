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

    public UnityEditor.SceneAsset menuScene;
    [SerializeField] UnityEditor.SceneAsset gameScene;

    public void LoadMenu(){
        SceneManager.LoadScene(menuScene.name);
    }

    public void LoadGame(){
        SceneManager.LoadScene(gameScene.name);
    }
}
