using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [Range(0, 10)]
    public float speed = 1.0f;
    public Transform pathParent;

    void Awake()
    {
        Vector3[] path = new Vector3[pathParent.childCount];
        for (int i = 0; i < pathParent.childCount; i++)
        {
            path[i] = transform.GetChild(i).transform.position;
        }
    }

    void OnDrawGizmos() {
		Vector3 startPosition = pathParent.GetChild(0).position;
		Vector3 previousPosition = startPosition;

		foreach (Transform waypoint in pathParent) {
			Gizmos.DrawSphere (waypoint.position, .3f);
			Gizmos.DrawLine (previousPosition, waypoint.position);
			previousPosition = waypoint.position;
		}
		Gizmos.DrawLine (previousPosition, startPosition);
	}
}
