using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=11ofnLOE8pw
public class FollowRoute : MonoBehaviour
{
    [SerializeField] private Transform[] routes;
    [SerializeField] private int playerNum;

    private int routeToGo;
    private float tParam;
    private Vector3 playerPos;
    private float speedModifier;

    private bool coroutineAllowed;

    private void Start()
    {
        routeToGo = 0;
        tParam = 0f;
        var baseSpeed = 0.25f;
        // TODO: Use speed of monster rather than random value
        speedModifier = baseSpeed + (/*RaceOne.speed*/ Random.Range(1f, 80f) / 100 * baseSpeed);
        coroutineAllowed = true;
    }

    private void Update()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }
    }

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            playerPos = Mathf.Pow(1 - tParam, 3) * p0 +
                        3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                        3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                        Mathf.Pow(tParam, 3) * p3;
            
            transform.LookAt(playerPos);

            transform.position = playerPos;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;

        routeToGo += 1;

        if (routeToGo > routes.Length - 1)
        {
            routeToGo = 0;
        }

        coroutineAllowed = true;
    }
}