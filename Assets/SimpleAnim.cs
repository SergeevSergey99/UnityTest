using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnim : MonoBehaviour
{
    public float StartDeltaX, Speed;
    // Start is called before the first frame update
    Vector3 startPos;
    Vector3 startScale;
    void Start()
    {
        startPos = transform.position;
        startScale = transform.localScale;
        transform.Translate(StartDeltaX, 0, 0);
        StartCoroutine(Moving());
        StartCoroutine(Scalling());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator Moving()
    {
        Vector3 pos = transform.position;
        float t = 0;

        while(t <= 1)
        {
            yield return null; // new WaitForSeconds(0.5f);
            transform.position = Vector3.Lerp(pos, startPos, t);
            t += 0.01f;
        }
    }
    IEnumerator Scalling()
    {
        float t = 0;

        while(t <= 1)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale = Vector3.Lerp(Vector3.zero, startScale, t);
            t += 0.01f;
        }
    }
}
