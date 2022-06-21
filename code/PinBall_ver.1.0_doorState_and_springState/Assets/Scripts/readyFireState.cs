using UnityEngine;
using UnityEditor;

public class readyFireState : springState //발사를 기다리는 상태
{
    public bool ready()
    {
        Debug.Log("Ready");
        return true;
    }
    public bool moveBackward()
    {
        return false;
    }
    public bool shooting()
    {
        return false;
    }
    public bool moveOriginalPosition()
    {
        return false;
    }
}