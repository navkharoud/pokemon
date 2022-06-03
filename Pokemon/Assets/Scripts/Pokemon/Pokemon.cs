 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Pokemon", menuName ="Pokemon/Create new pokemon")]

public class Pokemon : ScriptableObject
{
    [SerializeField] private string _name;
    [TextArea]
    [SerializeField] private string _description;
    [SerializeField] private Sprite _frontSprite;
    [SerializeField] private Sprite _backSprite;

    [SerializeField] private PokemonType _type1;
    [SerializeField] private PokemonType _type2;


    [SerializeField] private int _maxHP;
    [SerializeField] private int _attack;
    [SerializeField] private int _defense;
    [SerializeField] private int _specialAttack;
    [SerializeField] private int _specialDefense;
    [SerializeField] private int _speed;

    [SerializeField] List<LearnableMove> _learnableMoves;

    public List<LearnableMove> LearnableMoves {
        get { return _learnableMoves; }
    }

    public Sprite BackSprite { 
        get { return _backSprite; }
    }
    public Sprite FrontSprite {
        get { return _frontSprite;  }
    }

    public string Name { 
        get { return _name; }   
    }
    public string Description
    {
        get { return _description; }
    }
    
    public PokemonType Type1 { 
        get { return _type1; }    
    }
    public PokemonType Type2
    {
        get { return _type1; }
    }
   
    public int MaxHP { 
        get { return _maxHP; }
    }
    public int Attack { 
        get { return _attack; }
    }
    public int Defense { 
        get { return _defense; }
    }
    public int SpecialAttack { 
        get { return _specialAttack; }  
    }

    public int SpecialDefense {
        get { return _specialDefense; }
    }
    public int Speed { 
        get { return _speed; }  
    }


    
}
public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon

}


//Not implemented yet
public class TypeChart{
    float[][] chart = { 
           //Has to be same order as PokemonType class
        //                       Nor   Fir   Wat   Ele   Gra   Ice   Fig   Poi   Gro   Fly   Psy   Bug   Roc   Gho   Dra   Dar  Ste    Fai
        /*Normal*/  new float[] {1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 0,    1f,   1f,   0.5f, 1f},
        /*Fire*/    new float[] {1f,   0.5f, 0.5f, 1f,   2f,   2f,   1f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   0.5f, 1f,   2f,   1f},
        /*Water*/   new float[] {1f,   2f,   0.5f, 1f,   0.5f, 1f,   1f,   1f,   2f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f,   1f,   1f},
        /*Electric*/new float[] {1f,   1f,   2f,   0.5f, 0.5f, 1f,   1f,   1f,   0f,   2f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   1f},
        /*Grass*/   new float[] {1f,   0.5f, 2f,   1f,   0.5f, 1f,   1f,   0.5f, 2f,   0.5f, 1f,   0.5f, 2f,   1f,   0.5f, 1f,   0.5f, 1f},
        /*Ice*/     new float[] {1f,   0.5f, 0.5f, 1f,   2f,   0.5f, 1f,   1f,   2f,   2f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f},
        /*Fighting*/new float[] {2f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 1f,   0.5f, 0.5f, 0.5f, 2f,   0f,   1f,   2f,   2f,   0.5f},
        /*Poison*/  new float[] {1f,   1f,   1f,   1f,   2f,   1f,   1f,   0.5f, 0.5f, 1f,   1f,   1f,   0.5f, 0.5f, 1f,   1f,   0f,   2f},
        /*Ground*/  new float[] {1f,   2f,   1f,   2f,   0.5f, 1f,   1f,   2f,   1f,   0f,   1f,   0.5f, 2f,   1f,   1f,   1f,   2f,   1f},
        /*Flying*/  new float[] {1f,   1f,   1f,   0.5f, 2f,   1f,   2f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   0.5f, 1f},
        /*Psychic*/ new float[] {1f,   1f,   1f,   1f,   1f,   1f,   2f,   2f,   1f,   1f,   0.5f, 1f,   1f,   1f,   1f,   0f,   0.5f, 1f},
        /*Bug*/     new float[] {1f,   0.5f, 1f,   1f,   2f,   1f,   0.5f, 0.5f, 1f,   0.5f, 2f,   1f,   1f,   0.5f, 1f,   2f,   0.5f, 0.5f},
        /*Rock*/    new float[] {1f,   2f,   1f,   1f,   1f,   2f,   0.5f, 1f,   0.5f, 2f,   1f,   2f,   1f,   1f,   1f,   1f,   0.5f, 1f},
        /*Ghost*/   new float[] {0f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   2f,   1f,   0.5f, 1f,   1f},
        /*Dragon*/  new float[] {1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   1f,   2f,   1f,   0.5f, 0f},
        /*Dark*/    new float[] {1f,   1f,   1f,   1f,   1f,   1f,   0.5f, 1f,   1f,   1f,   2f,   1f,   1f,   2f,   1f,   0.5f, 1f,   0.5f},
        /*Steel*/   new float[] {1f,   0.5f, 0.5f, 0.5f, 1f,   2f,   1f,   1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   0.5f, 2f},
        /*Fairy*/   new float[] {1f,   0.5f, 1f,   1f,   1f,   1f,   2f,   0.5f, 1f,   1f,   1f,   1f,   1f,   1f,   2f,   2f,   0.5f, 1f},

    };
}

//makes this appear in the inspector
[System.Serializable]
public class LearnableMove {
    [SerializeField] MoveBase _movebase; 
    [SerializeField] int _level;
    public int Level {  get { return _level; } }
    public MoveBase MoveBase { get { return _movebase; } }
}