using UnityEngine;
using UnityEditor;

public class closedState : doorState //문이 다 닫힌 상태
{
    public bool ready()
    {
        return false;
    }
    public bool movingStart()
    {
        return false;
    }
    public bool moving()
    {
        return false;
    }
    public bool closed()
    {
        Debug.Log("Closed");
        return true;
    }
}

