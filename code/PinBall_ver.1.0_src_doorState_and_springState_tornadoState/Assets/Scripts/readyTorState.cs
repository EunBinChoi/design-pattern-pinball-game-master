using UnityEngine;
using UnityEditor;

public class readyTorState : tornadoState
{
    public bool ready()
    {
        return true;
    }
    public bool activated()
    {
        return false;
    }
}