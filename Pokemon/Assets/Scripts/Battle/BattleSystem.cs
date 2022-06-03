using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] AudioClip sceneMusic;
    [SerializeField] AudioClip victoryMusic;
    [SerializeField] BattleUnit _playerUnit;
    [SerializeField] BattleUnit _enemyUnit;

    [SerializeField] BattleHud _playerHud;
    [SerializeField] BattleHud _enemyHud;
    [SerializeField] BattleDialogueBox _dialogueBox;
    public event Action<bool> OnBattleOver;

    BattleState state;
   


    //in our action texts list we have fight at zero index and run at 1 index and we wil
    //base those values in the current action
    int currentAction;
    int currentMove;


    public void StartBattle()
    {
        AudioManager.Instance.PlayMusic(sceneMusic,true);
        StartCoroutine(SetupBattle());
        
    }

    public IEnumerator SetupBattle() {
        _playerUnit.Setup();
        _enemyUnit.Setup();
        _enemyHud.setData(_enemyUnit.Base);
        _playerHud.setData(_playerUnit.Base);
        _dialogueBox.SetMoveNames(_playerUnit.Base.Moves);
        //string interpelation
        yield return (_dialogueBox.TypeDialog($"A wild {_enemyUnit.Base._base.name} has appeared"));

        yield return new WaitForSeconds(1f);
        PlayerAction();
       
    }
    public void PlayerAction() {
        state = BattleState.PlayerAction;
        StartCoroutine(_dialogueBox.TypeDialog("Choose an action"));
        _dialogueBox.EnableActionText(true);
    }
    public void PlayerMove() {
        state = BattleState.PlayerMove;
        _dialogueBox.EnableActionText(false);
        _dialogueBox.EnableDialogText(false);
        _dialogueBox.EnableMoveText(true);
    }

    IEnumerator PerformPlayerMove() {
        state = BattleState.Busy;
        var move = _playerUnit.Base.Moves[currentMove];
        yield return _dialogueBox.TypeDialog($"{_playerUnit.Base._base.Name} used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isFainted = _enemyUnit.Base.TakeDamage(move, _playerUnit.Base);
        yield return _enemyHud.UpdateHP();
        if (isFainted)
        {
            AudioManager.Instance.PlayMusic(victoryMusic, false);
            yield return _dialogueBox.TypeDialog($"{_enemyUnit.Base._base.Name} fainted");
            OnBattleOver(true);
        }
        else {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove() {
        state = BattleState.EnemyMove;
        var move = _enemyUnit.Base.GetRandomMove();
        yield return _dialogueBox.TypeDialog($"{_enemyUnit.Base._base.Name} used {move.Base.Name}");
        yield return new WaitForSeconds(1f);

        bool isFainted = _playerUnit.Base.TakeDamage(move, _enemyUnit.Base);
        yield return _playerHud.UpdateHP();

        if (isFainted)
        {
            yield return _dialogueBox.TypeDialog($"{_playerUnit.Base._base.Name} fainted");
            OnBattleOver(false);
        }
        else
        {
            PlayerAction();
        }


    }
    public void HandleUpdate()
    {
        if (state == BattleState.PlayerAction) {
            HandleAction();
        }
        else if (state == BattleState.PlayerMove) {
            HandleMoves();
        }
    }
    private void HandleAction() {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            if (currentAction < 1)
            {
                ++currentAction;

            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) ){
            if (currentAction>0) {
                --currentAction;
            
            }
        }
        _dialogueBox.UpdateActionSelection(currentAction);
        if (Input.GetKeyDown(KeyCode.Z)) {
            if (currentAction ==  0) {
                //fight
                PlayerMove();
            }
            else if (currentAction == 1){ 
                //move
            }
        }
    }
    private void HandleMoves() {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < _playerUnit.Base.Moves.Count - 1)
            {
                ++currentMove;

            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
            {
                --currentMove;

            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > _playerUnit.Base.Moves.Count - 2)
            {
                currentMove += 2;

            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove > 1)
            {
                currentMove -= 2;

            }
        }

        _dialogueBox.UpdateMoveSelection(currentMove, _playerUnit.Base.Moves[currentMove]);
        if (Input.GetKeyDown(KeyCode.Z)) {
            _dialogueBox.EnableMoveText(false);
            _dialogueBox.EnableDialogText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }
    
}
