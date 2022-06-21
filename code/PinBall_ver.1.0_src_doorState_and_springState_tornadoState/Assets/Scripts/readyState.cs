using UnityEngine;
using UnityEditor;

public class readyState : doorState //공이 지나가길 기다리는 상태
{
    public bool ready()
    {
        return true;
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
        return false;
    }
}