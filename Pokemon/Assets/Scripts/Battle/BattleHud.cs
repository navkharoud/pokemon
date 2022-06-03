using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text _nameText;
    [SerializeField] Text _levelText;
    [SerializeField] HPbar _hpbar;
    PokemonBase _pokemon;
    public void setData(PokemonBase pokemon) {
        _pokemon = pokemon;
        _nameText.text = pokemon._base.Name;
        _levelText.text = "Lvl" + pokemon._level;
        _hpbar.SetHP((float) pokemon.HP/pokemon.MaxHP);
    }
    public IEnumerator UpdateHP() {
       yield return _hpbar.SetHPsmooth((float)_pokemon.HP / _pokemon.MaxHP);
    }
}

