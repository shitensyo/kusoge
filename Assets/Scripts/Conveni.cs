using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Conveni
{
    static public Vector2 ScreenToWorld(Vector3 screen)
    {
        if(Camera.main == null) return Vector2.zero;

        var camera = Camera.main;
        screen.z = camera.transform.position.z;

        return camera.ScreenToWorldPoint(screen);
    }
}
