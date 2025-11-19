using UnityEngine;
using UnityEngine.Events;

public class SCR_GameManager : MonoBehaviour{
    //SINGLETON START
    public static SCR_GameManager Instance {get; private set;}
    void Awake(){
        if (Instance != null && Instance != this){
            Destroy(this);
        }else{
            Instance = this;
        }
    }
    //SINGLETON END
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameCamera;
    public UnityEvent onPause;
    public UnityEvent onUnPause;
    bool paused;
    bool unPauseForbidden;

    void Update(){
        if (Input.GetKeyDown("escape")){
            TryTogglePause();
        }
    }

    public void TryUnpause(){
        if ((unPauseForbidden) || (!paused)) return;
        onUnPause.Invoke();
        Time.timeScale = 1f;
        paused = false;
        SCR_GameUiPanelsManager.Instance.ClosePanel();
    }

    void TryPause(){
        onPause.Invoke();
        paused = true;
        Time.timeScale = 0f;
        SCR_GameUiPanelsManager.Instance.OpenPanel(SCR_GameUiPanelsManager.Panel.Pause);
    }

    void TryTogglePause(){
        if (paused) TryUnpause();
        else TryPause();
    }

    public GameObject GetPlayer(){
        return player;
    }

    public Vector2 GetPlayerPosition(){
        return player.transform.position;
    }

    public Vector2 GetCameraPosition(){
        return gameCamera.transform.position;
    }
}
