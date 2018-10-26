using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour {

    public NavMeshAgent agent;
    public GameObject[] waypoints;
    private int currentTaget = 0;


	void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(waypoints[0].transform.position);
	}

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name + ", " + waypoints[currentTaget].name);

        if (collision.gameObject == waypoints[currentTaget])
        {

            if (currentTaget == waypoints.Length - 1)
            {
                currentTaget = 0;
            }
            else
            {
                currentTaget++;
            }
            Debug.Log(currentTaget + ",  " + agent.destination);
            agent.ResetPath();
            agent.SetDestination(waypoints[currentTaget].transform.position);
        }
    }
}
