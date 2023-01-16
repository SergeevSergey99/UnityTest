using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int[,] maze = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void initMaze(int[,] newMaze)
    {
        maze = newMaze;
    }

    public float Speed = 10;

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float dirY = -Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        if (dirY > 0 &&
            (transform.position.z - (int)(transform.position.z) < 0.2 || 
            transform.position.z - (int)(transform.position.z) > 0.8)
            && maze[(int)(transform.position.x + dirY + 0.9),
            (int)(transform.position.z + 0.2)] == 0)
            transform.Translate(dirY, 0, 0);
        if (dirY < 0 &&
            (transform.position.z - (int)(transform.position.z) < 0.2 ||
            transform.position.z - (int)(transform.position.z) > 0.8)
            && maze[(int)(transform.position.x + dirY),
            (int)(transform.position.z+0.2)] == 0)
            transform.Translate(dirY, 0, 0);
        if (dirX > 0 &&
            (transform.position.x - (int)(transform.position.x) < 0.2 ||
            transform.position.x - (int)(transform.position.x) > 0.8)
            && maze[(int)(transform.position.x+0.2),
            (int)(transform.position.z + dirX + 0.9)] == 0)
            transform.Translate(0, 0, dirX);
        if (dirX < 0 &&
            (transform.position.x - (int)(transform.position.x) < 0.2 ||
            transform.position.x - (int)(transform.position.x) > 0.8)
            && maze[(int)(transform.position.x+0.2),
            (int)(transform.position.z + dirX)] == 0)
            transform.Translate(0, 0, dirX);
    }
}
