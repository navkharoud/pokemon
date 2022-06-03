using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase
{
    public Pokemon _base { get; set; }
    public int _level { get; set; }

    public int HP {
        get; set;
    }

    public List<Move> Moves { get; set; }

    public PokemonBase(Pokemon p, int lvl) { 
        _base = p;  
        _level = lvl;
        HP = MaxHP;
        Moves = new List<Move>();

        // Generate moves based on level
        foreach (var move in _base.LearnableMoves) {
            if (move.Level<= _level) {
                Moves.Add(new Move(move.MoveBase));

            }
            if (Moves.Count >= 4) {
                break;
                //exit if more than 4 moves
            }
        }
    }

    public int Attack {
        get { return Mathf.FloorToInt((_base.Attack*_level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((_base.Defense * _level) / 100f) + 5; }
    }
    public int SpecialAttact
    {
        get { return Mathf.FloorToInt((_base.SpecialAttack * _level) / 100f) + 5; }
    }
    public int SpecialDefense
    {
        get { return Mathf.FloorToInt((_base.SpecialDefense * _level) / 100f) + 5; }
    }
    public int Speed
    {
        get { return Mathf.FloorToInt((_base.Speed * _level) / 100f) + 5; }
    }
    public int MaxHP
    {
        get { return Mathf.FloorToInt((_base.MaxHP * _level) / 100f) + 5; }
    }
    public bool TakeDamage(Move move, PokemonBase attacker) {
        //damage formulae taken form bublapedia 
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2*attacker._level+10)/250f;
        float d = a * move.Base.Power * ((float)attacker.Attack/Defense)+2;
        int damage = Mathf.FloorToInt(d*modifiers);
        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        else return false;
    }
    public Move GetRandomMove() {
        int r = Random.Range(0,Moves.Count);
        return Moves[r];
    
    }
}
