using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/Item")]
public class Item : ScriptableObject
{
    public string Name;
    [TextArea]
    public string Description;
    public Sprite Icon;
    public float Cost;
    public float Weight;
}
