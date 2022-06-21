using UnityEngine;
using UnityEditor;

public class activeState : tornadoState
{
    public bool ready()
    {
        return false;
    }
    public bool activated()
    {
        return true;
    }
}
