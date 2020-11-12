using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField] private GameObject _toFollow;
    [SerializeField] private bool _followPosition, _followRotation;

    void Update()
    {
        if (_followPosition)
        {
            transform.position = _toFollow.transform.position;
        }

        if (_followRotation)
        {
            transform.rotation = _toFollow.transform.rotation;
        }
    }
}