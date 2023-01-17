using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    MazeGenerator mg;
    public int x, y;
    public int VALUE;

    public void init(MazeGenerator MG, int X, int Y, int V)
    {
        mg = MG;
        x = X;
        y = Y;
        VALUE = V;
    }
    private void OnMouseDown()
    {
        Debug.Log(x + " " + y);
        mg.CalcBFS(this);
    }
}
