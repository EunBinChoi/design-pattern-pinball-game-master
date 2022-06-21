using UnityEngine;
using UnityEditor;

public class releaseButtonState : springState  //발사 키가 릴리즈 된 상태
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
        return true;
    }
    public bool moveOriginalPosition()
    {
        return false;
    }
}