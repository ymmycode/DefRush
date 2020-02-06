using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Waypoint> path;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position; //make enemy position follow the waypoint object
            yield return new WaitForSeconds(1); // hold 1 sec
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
