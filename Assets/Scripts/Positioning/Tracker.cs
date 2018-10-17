using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This is a class to keep the information of the player position, 
 * where the player faces to, the camera position and angle.
 */
public class Tracker {
    //camera position
    public Vector3 camPos {
        get;set;
    }

    //camera angle
    public Vector3 camAngle
    {
        get;set;
    }

    //player position
    public Vector3 playerPos
    {
        get;set;
    }

    //where player faces to
    public Vector3 playerAngle
    {
        get;set;
    }



}
