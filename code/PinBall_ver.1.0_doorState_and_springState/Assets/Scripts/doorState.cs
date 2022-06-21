using UnityEngine;
using UnityEditor;

public interface doorState
{
    bool ready();
    bool movingStart();
    bool moving();
    bool closed();
}

