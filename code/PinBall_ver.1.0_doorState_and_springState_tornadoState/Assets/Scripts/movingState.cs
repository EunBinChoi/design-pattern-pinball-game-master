using UnityEngine;
using UnityEditor;

public class movingState : doorState //공이 지나가고 문이 움직이고 있는 상태
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
        return true;
    }
    public bool closed()
    {
        return false;
    }
}