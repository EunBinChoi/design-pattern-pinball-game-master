using UnityEngine;
using UnityEditor;

public class passedState : doorState //공이 지나간 상태
{
    public bool ready()
    {
        return false;
    }
    public bool movingStart()
    {
        Debug.Log("Passed");
        return true;
    }
    public bool moving()
    {
        return false;
    }
    public bool closed()
    {
        return false;
    }
}