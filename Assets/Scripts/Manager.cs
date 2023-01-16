using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
   public void RotateGameObject(GameObject go, float x, float y, float z) 
   {
        /*
         Многа кода
         */
        go.GetComponent<Transform>().Rotate(x, y, z, Space.World);
   }

    private void Update()
    {
        /*
         Многа кода
         */
    }
}
