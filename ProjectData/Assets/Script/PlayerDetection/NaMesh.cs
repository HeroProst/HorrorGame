using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NaMesh : MonoBehaviour {

	public NavMeshAgent agent;

	public void GoToTarget(Vector3 targetPosition){
		agent.SetDestination(targetPosition);
	}

}