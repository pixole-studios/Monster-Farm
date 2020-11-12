using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=11ofnLOE8pw
public class DrawRoute : MonoBehaviour
{
    [SerializeField] private Transform[] _controlPoints;

    private Vector3 gizmosPosition;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPosition = Mathf.Pow(1 - t, 3) * _controlPoints[0].position +
                             3 * Mathf.Pow(1 - t, 2) * t * _controlPoints[1].position +
                             3 * (1 - t) * Mathf.Pow(t, 2) * _controlPoints[2].position +
                             Mathf.Pow(t, 3) * _controlPoints[3].position;
            Gizmos.DrawSphere(gizmosPosition, 2f);
        }

        Gizmos.DrawLine(
            new Vector3(_controlPoints[0].position.x, _controlPoints[0].position.y, _controlPoints[0].position.z),
            new Vector3(_controlPoints[1].position.x, _controlPoints[1].position.y, _controlPoints[1].position.z));
        
        Gizmos.DrawLine(
            new Vector3(_controlPoints[2].position.x, _controlPoints[2].position.y, _controlPoints[2].position.z),
            new Vector3(_controlPoints[3].position.x, _controlPoints[3].position.y, _controlPoints[3].position.z));
    }
}