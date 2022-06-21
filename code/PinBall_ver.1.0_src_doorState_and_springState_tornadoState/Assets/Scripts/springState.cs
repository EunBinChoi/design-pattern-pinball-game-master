using UnityEngine;
using UnityEditor;

public interface springState
{
    bool ready();
    bool moveBackward();
    bool shooting();
    bool moveOriginalPosition();
}