using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ratator : MonoBehaviour
{
    public float Speed = 1;
    public Vector3 angle;
    Manager mng = null;
    private void Awake()
    {
        Debug.Log("Awake");
        mng = FindObjectOfType<Manager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Transform>().Rotate(Vector3.up);
        GetComponent<Transform>().Rotate(angle * Speed * Time.deltaTime, Space.World);

        
        if (Input.GetButtonDown("Space"))
        {
            Destroy(gameObject);
        }

    }
    private void LateUpdate()
    {
        
    }
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }

    private void OnMouseDown()
    {
        //gameObject.SetActive(false);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        Debug.Log("Destroying");
    }
}
