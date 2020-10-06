using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Robot", menuName
= "Robot Creation/Structure")]

public class RobotInfo : ScriptableObject
{
    public int id;
    public int mass;
    public Material color;

    public void PrintMessage()
    {
        Debug.Log("Robot ID " + id + " has been loaded");
    }

}
