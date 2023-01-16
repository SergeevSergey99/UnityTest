using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject WallPrefab, FloorPrefab, PlayerPrefab;
    public Vector2 startPos = Vector2.one;
    int[,] maze = new int[10, 10] 
    { 
        {1,1,1,1,1,1,1,1,1,1}, 
        {1,0,0,0,0,1,0,0,0,1}, 
        {1,1,1,1,0,1,0,1,0,1},
        {1,0,0,0,0,1,0,1,0,1}, 
        {1,1,1,0,1,1,0,1,0,1}, 
        {1,0,0,0,0,0,0,0,0,1},
        {1,1,0,1,1,1,1,1,0,1}, 
        {1,0,0,0,0,0,1,0,0,1}, 
        {1,0,1,0,1,0,0,0,1,1}, 
        {1,1,1,1,1,1,1,1,1,1} 
    };
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                if (maze[x, y] == 0)
                {
                    // Floor
                    GameObject go = Instantiate(FloorPrefab, transform);
                    go.transform.position = new Vector3(
                        x, go.transform.position.y, y);
                }
                else if(maze[x, y] == 1)
                {
                    // Wall
                    GameObject go = Instantiate(WallPrefab, transform);
                    go.transform.position = new Vector3(
                        x, go.transform.position.y, y);
                }
            }
        }

        GameObject player = Instantiate(PlayerPrefab,transform);
        player.transform.position = new Vector3(
            startPos.x, player.transform.position.y, startPos.y);
        player.GetComponent<PlayerController>().initMaze(maze);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
