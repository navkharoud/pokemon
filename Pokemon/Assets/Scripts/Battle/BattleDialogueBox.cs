using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { 
    Start, 
    PlayerAction, 
    PlayerMove, 
    EnemyMove, 
    Busy
}

public class BattleDialogueBox : MonoBehaviour
{
    [SerializeField] private Text _dialogue;
    [SerializeField] int letterPerSecond;
    [SerializeField] GameObject _actionSelector;
    [SerializeField] GameObject _moveSelector;
    [SerializeField] GameObject _moveDetails;

    [SerializeField] List<Text> _actionTexts;
    [SerializeField] List<Text> _moveTexts;

    [SerializeField] Text _ppText;
    [SerializeField] Text _typeTexts;

    [SerializeField] Color colourHighlight;

    
    public void setDialog(string dialog) {
        _dialogue.text = dialog;
    }

    //Coroutine for dialog styling to appear letter after letter 
    public IEnumerator TypeDialog(string dialog) {
        _dialogue.text = "";
        foreach (var letter in dialog.ToCharArray()) {
            _dialogue.text += letter;
            yield return new WaitForSeconds(1f/letterPerSecond);
        }
        
    }

    public void EnableDialogText(bool enabled) { 
        _dialogue.enabled = enabled;    
    }
    public void EnableActionText(bool enabled)
    {
        _actionSelector.SetActive(enabled);
    }
    public void EnableMoveText(bool enabled)
    {
        _moveSelector.SetActive(enabled);
        _moveDetails.SetActive(enabled);    
    }
    public void UpdateActionSelection(int selectedAction) {
        //loop thru action selection 
        for (int i = 0; i<_actionTexts.Count;++i) {
            if (i == selectedAction)
            {
                _actionTexts[i].color = colourHighlight;
            }
            else {
                _actionTexts[i].color = Color.black;

            }
        
        }
    }
    public void SetMoveNames(List<Move> moves) {
        for (int i = 0; i<_moveTexts.Count;++i) {
            //since some pokemon can have less than 4 moves we have to check for that aswell
            if (i < moves.Count)
            {
                _moveTexts[i].text = moves[i].Base.name;
            }
            else {
                _moveTexts[i].text = "-";
            }
        }
    }
    public void UpdateMoveSelection(int selectedMove, Move move) {
        for (int i = 0; i < _moveTexts.Count; ++i)
        {
            if (i == selectedMove)
            {
                _moveTexts[i].color = colourHighlight;
            }
            else
            {
                _moveTexts[i].color = Color.black;

            }

        }
        _ppText.text = $"{move.PP}/{move.Base.PP}";
        _typeTexts.text = move.Base.Type.ToString();
    }
}
