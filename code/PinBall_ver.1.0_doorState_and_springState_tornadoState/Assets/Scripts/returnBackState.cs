using UnityEngine;
using UnityEditor;

public class returnBackState : springState  //발사대를 원래 위치로 복귀
{
    public bool ready()
    {
        return false;
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
        return true;
    }
}