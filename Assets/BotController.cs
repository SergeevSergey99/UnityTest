using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    Vector3 NextPos; 

    private void Start()
    {
        StartCoroutine(Moving());
    }
    IEnumerator Moving()
    {
        NextPos = FindObjectOfType<MazeGenerator>().FindNextPosToPlayer(this);
        Vector3 startPos = transform.position;
        float t = 0;

        while (t <= 1)
        {
            yield return null;
            transform.position = Vector3.Lerp(startPos, NextPos, t);
            t += 0.01f;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Moving());
    }
}
