using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//State Design Pattern and Observer design pattern used 
public enum GameState{ 
    FreeRoam, 
    Battle
}

public class GameController : MonoBehaviour
{
    [SerializeField] Player PlayerController;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] Camera MainCamera;
    [SerializeField] GameObject inventory;
    GameState state;

    private void Start()
    {
        PlayerController.onEncounter += StartBattle;
        battleSystem.OnBattleOver += EndBattle;
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    void StartBattle() { 
        state = GameState.Battle;
        battleSystem.gameObject.SetActive(true);
        MainCamera.gameObject.SetActive(false);
        inventory.gameObject.SetActive(false);
        battleSystem.StartBattle();
    }

    void EndBattle(bool won) {
       
        state = GameState.FreeRoam;
        battleSystem.gameObject.SetActive(false);
        MainCamera?.gameObject.SetActive(true);
        inventory.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (state == GameState.FreeRoam) { 
            PlayerController.HandleUpdate();
        
        }
        else if (state == GameState.Battle){ 
            battleSystem.HandleUpdate();
        
        }
    }

}
