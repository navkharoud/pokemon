using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Move", menuName ="Pokemon/Create new move")]

public class MoveBase : ScriptableObject
{
    [SerializeField] string _name; 
    [TextArea]
    [SerializeField] string _description;
    [SerializeField] PokemonType type;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int pp;

    public string Name { 
    get { return _name; }
    }
    public string Description { 
    get { return _description; }
    }
    public PokemonType Type { 
    get { return type; }
    }
    public int Power { 
        get { return power; }
    }
    public int Accuracy { 
        get { return accuracy; }
    }
    public int PP { 
    get { return pp; }
    }
}
