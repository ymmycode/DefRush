using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float enemyMovementSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
           transform.position = waypoint.transform.position; //make enemy position follow the waypoint object
            yield return new WaitForSeconds(enemyMovementSpeed); // hold 1 sec
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
