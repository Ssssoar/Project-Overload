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
    public UnityEvent onFreeze;
    public UnityEvent onUnfreeze;
    bool paused;
    bool frozen;
    bool unPauseForbidden;

    void Update(){
        if (Input.GetKeyDown("escape")){
            TryTogglePause();
        }
    }

    void TryTogglePause(){
        if (paused) TryUnpause();
        else TryPause();
    }

    public void TryUnpause(){
        if ((unPauseForbidden) || (!paused)) return;
        onUnPause.Invoke();
        FreezeState(false);
        paused = false;
        SCR_GameUiPanelsManager.Instance.ClosePanel();
    }

    void TryPause(){
        if (paused) return;
        onPause.Invoke();
        FreezeState(true);
        paused = true;
        SCR_GameUiPanelsManager.Instance.OpenPanel(SCR_GameUiPanelsManager.Panel.Pause);
    }

    public void FreezeState(bool freeze){
        Time.timeScale = (freeze)? 0f: 1f;
        frozen = freeze;
        if (freeze){
            onFreeze?.Invoke();
        }else{
            onUnfreeze?.Invoke();
        }
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
