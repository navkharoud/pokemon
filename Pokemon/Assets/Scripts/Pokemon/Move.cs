using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move 
{
    public MoveBase Base { get; set; }
    public int PP { get; set; }

    public Move(MoveBase b) {
        Base = b;
        PP = Base.PP;
    
    }
}
