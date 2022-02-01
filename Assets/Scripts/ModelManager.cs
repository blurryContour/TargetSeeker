using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

public class ModelManager : MonoBehaviour
{
    [Range(0, 3)]
    public int defaultLevel;
    public Transform obstacle;
    
    private float obstacleLength;
    private List<Vector2> lengthRange = new List<Vector2>();
  
    // Start is called before the first frame update
    void Start()
    {
        // Obstacle Length Ranges
        lengthRange.Add(new Vector2(0.01f, 1f)); // level 0
        lengthRange.Add(new Vector2(1f, 4.5f));    // level 1
        lengthRange.Add(new Vector2(4.5f, 9f));    // level 2
        lengthRange.Add(new Vector2(10f, 10f));    // level 3

        // Set obstacle length
        ResetArena();
    }

    public void ResetArena()
    {
        // Set obstacle length
        int agentLevel = (int)Academy.Instance.EnvironmentParameters.GetWithDefault("agent_level", (float)defaultLevel);
        obstacleLength = Random.Range(lengthRange[agentLevel].x, lengthRange[agentLevel].y);
        obstacle.localScale = new Vector3(0.5f, 1.5f, obstacleLength);
    }

}
