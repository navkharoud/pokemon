using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{

    [SerializeField] private Pokemon _pokemon;
    [SerializeField] private int _lvl;
    [SerializeField] private bool isPlayer;
    public PokemonBase Base { get;  set; }
    public void Setup() {
        Base = new PokemonBase(_pokemon, _lvl);
        if (isPlayer)
        {
            GetComponent<Image>().sprite = Base._base.BackSprite;

        }
        else { 
            GetComponent<Image>().sprite = Base._base.FrontSprite;
        }
    }

}
