using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public GameObject WallPrefab, FloorPrefab, PlayerPrefab;
    public Vector2 startPos = Vector2.one;
    public Material blue, green;
    PlayerController player;
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
    Node[,] nodeMaze = new Node[10, 10]; 
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
                    go.GetComponent<Node>().init(this, x, y, maze[x, y]);
                    nodeMaze[x, y] = go.GetComponent<Node>();
                }
                else if(maze[x, y] == 1)
                {
                    // Wall
                    GameObject go = Instantiate(WallPrefab, transform);
                    go.transform.position = new Vector3(
                        x, go.transform.position.y, y);
                    go.GetComponent<Node>().init(this, x, y, maze[x, y]);
                    nodeMaze[x, y] = go.GetComponent<Node>();
                }
            }
        }

        GameObject playerGO = Instantiate(PlayerPrefab,transform);
        playerGO.transform.position = new Vector3(
            startPos.x, playerGO.transform.position.y, startPos.y);
        playerGO.GetComponent<PlayerController>().initMaze(maze);
        player = playerGO.GetComponent<PlayerController>();

    }

    public void CalcBFS(Node node)
    {
        for (int x = 0; x < 10; x++)
            for (int y = 0; y < 10; y++)
                if(maze[x,y] == 0) 
                    nodeMaze[x, y].GetComponent<MeshRenderer>().material = blue;

        int startX = (int) (player.transform.position.x + 0.2);
        int startY = (int) (player.transform.position.z + 0.2);
        int endX = (int) node.x;
        int endY = (int) node.y;

        int[,] pathPoints = new int[10,10];
        for(int x = 0; x < 10; x++)
            for (int y = 0; y < 10; y++)
                pathPoints[x, y] = int.MinValue;

        pathPoints[startX, startY] = 0;

        List<Node> queue = new List<Node>();
        queue.Add(nodeMaze[startX, startY]);
        List<Node> nextQueue = new List<Node>();
        int stepLevel = 1;


        while (queue.Count > 0)
        {
            var curr = queue[0];
            queue.RemoveAt(0);

            if (curr.x == endX && curr.y == endY)
                break;

            if (curr.x - 1 >= 0 && maze[curr.x - 1, curr.y] == 0
                && pathPoints[curr.x - 1, curr.y] == int.MinValue)
            {
                nextQueue.Add(nodeMaze[curr.x - 1, curr.y]);
                pathPoints[curr.x - 1, curr.y] = stepLevel;
            }
            if (curr.x + 1 < 10 && maze[curr.x + 1, curr.y] == 0
                && pathPoints[curr.x + 1, curr.y] == int.MinValue)
            {
                nextQueue.Add(nodeMaze[curr.x + 1, curr.y]);
                pathPoints[curr.x + 1, curr.y] = stepLevel;
            }
            if (curr.y - 1 >= 0 && maze[curr.x, curr.y - 1] == 0
                && pathPoints[curr.x, curr.y - 1] == int.MinValue)
            {
                nextQueue.Add(nodeMaze[curr.x, curr.y - 1]);
                pathPoints[curr.x, curr.y - 1] = stepLevel;
            }
            if (curr.y + 1 < 10 && maze[curr.x, curr.y + 1] == 0
                && pathPoints[curr.x, curr.y + 1] == int.MinValue)
            {
                nextQueue.Add(nodeMaze[curr.x, curr.y + 1]);
                pathPoints[curr.x, curr.y + 1] = stepLevel;
            }


            if(queue.Count == 0)
            {
                stepLevel++;
                queue.AddRange(nextQueue);
                nextQueue.Clear();
            }
        }

        if(pathPoints[endX, endY] == int.MinValue)
        {
            Debug.Log("Невозможный путь");
        }
        else
        {
            var curr = nodeMaze[endX, endY];
            while(pathPoints[curr.x, curr.y] != 0)
            {
                curr.GetComponent<MeshRenderer>().material = green;
                if (curr.x - 1 >= 0
                    && pathPoints[curr.x, curr.y] - 1 == pathPoints[curr.x - 1, curr.y])
                {
                    curr = nodeMaze[curr.x - 1, curr.y];
                    continue;
                }
                if (curr.x + 1 < 10
                    && pathPoints[curr.x, curr.y] - 1 == pathPoints[curr.x + 1, curr.y])
                {
                    curr = nodeMaze[curr.x + 1, curr.y];
                    continue;
                }
                if (curr.y - 1 >= 0
                    && pathPoints[curr.x, curr.y] - 1 == pathPoints[curr.x, curr.y - 1])
                {
                    curr = nodeMaze[curr.x, curr.y - 1];
                    continue;
                }
                if (curr.y + 1 < 10
                    && pathPoints[curr.x, curr.y] - 1 == pathPoints[curr.x, curr.y + 1])
                {
                    curr = nodeMaze[curr.x, curr.y + 1];
                    continue;
                }

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
