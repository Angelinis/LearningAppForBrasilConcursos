using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Graphic", menuName = "Assets/New Graphic")]
public class GraphicUnit : ScriptableObject
{
    public string graphicName;
    public float graphicScaleX;
    public float graphicScaleY;
    public float graphicScaleZ;
    public float graphicPositionX;
    public float graphicPositionY;
    public float graphicPositionZ;
}
