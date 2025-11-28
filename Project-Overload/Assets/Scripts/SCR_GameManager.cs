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
    [Header ("References")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameCamera;
    [SerializeField] SCR_Charger charger;
    [SerializeField] SCR_Blast blast;

    //Definitions
    public enum GameState{Playing, Paused, Upgrade, GameOver};
    [System.Serializable] public class GameStateEvent : UnityEvent<GameState> {}
    [System.Serializable] public class BoolEvent : UnityEvent<bool> {}

    [Header("Events")]
    public GameStateEvent onGameStateChange;
    public BoolEvent onFreezeStateChange;

    [Header("Variables")]
    bool frozen;
    GameState currentGameState = GameState.Playing;

    void Start(){
        FreezeState(false);
        SCR_WaveManager.Instance.onWaveIncrement.AddListener(TryUpgradeState);
    }

    void Update(){
        if (Input.GetKeyDown("escape")){
            TryTogglePause();
        }
    }

    void TryTogglePause(){
        if (currentGameState == GameState.Paused) TryChangeGameState(GameState.Playing);
        else if (currentGameState == GameState.Playing) TryChangeGameState(GameState.Paused);
    }

    public void TryUnpause(){
        if (currentGameState != GameState.Paused) return;
        TryChangeGameState(GameState.Playing);
    }

    public void TryUpgradeState(){
        TryChangeGameState(GameState.Upgrade);
    }

    public void TryEndUpgradeState(){
        if (currentGameState != GameState.Upgrade) return;
        TryChangeGameState(GameState.Playing);
    }

    public void TryGameOver(){
        TryChangeGameState(GameState.GameOver);
    }

    public void TryChangeGameState(GameState changeTo){
        bool allowed = false;
        if (
            (currentGameState == GameState.Playing) ||
            (changeTo == GameState.Playing) && ((currentGameState == GameState.Paused) || (currentGameState == GameState.Upgrade))
        ){
            allowed = true;
        }
        if (allowed) ChangeGameState(changeTo);
    }

    void ChangeGameState(GameState changeTo){
        currentGameState = changeTo;
        if ((changeTo == GameState.Paused) || (changeTo == GameState.Upgrade) || (changeTo == GameState.GameOver)){
            FreezeState(true);
        }else{
            FreezeState(false);
        }
        onGameStateChange?.Invoke(changeTo);
    }

    public void FreezeState(bool freeze){
        Time.timeScale = (freeze)? 0f: 1f;
        frozen = freeze;
        if (freeze){
            onFreezeStateChange?.Invoke(true);
        }else{
            onFreezeStateChange?.Invoke(false);
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

    public SCR_PlayerShooter GetPlayerShooter(){
        return player.GetComponent<SCR_PlayerShooter>();
    }

    public SCR_PlayerCharge GetPlayerCharge(){
        return player.GetComponent<SCR_PlayerCharge>();
    }

    public SCR_Health GetPlayerHealth(){
        return player.GetComponent<SCR_Health>();
    }

    public SCR_OverLoad GetPlayerOverLoad(){
        return player.GetComponent<SCR_OverLoad>();
    }

    public SCR_Charger GetCharger(){
        return charger;
    }

    public SCR_Blast GetPlayerBlast(){
        return blast;
    }
}
