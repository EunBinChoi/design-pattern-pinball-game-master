using UnityEngine;
using UnityEditor;

public class pressButtonState : springState //발사 키가 눌린 상태
{
    public bool ready()
    {
        return false;
    }
    public bool moveBackward()
    {
        return true;
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