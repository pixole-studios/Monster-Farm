using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private GameObject _owner;
    [SerializeField] private float _followSpeed;
    private bool _isSelected = false;
    private NavMeshAgent _navAgent;

    [SerializeField] private GameObject _selectedCursor;

    private bool _canMove = true;
    
    private void Start()
    {
        transform.localScale = transform.localScale / 3.5f;
        _navAgent = GetComponentInParent<NavMeshAgent>();
        _navAgent.speed = GetComponentInChildren<MonsterBuilder>().getSpeed() / 10f;
    }

    public void SetMonsterOwner(GameObject owner)
    {
        _owner = owner;
    }


    public void MoveMonsterTo(Vector3 pos)
    {
        if (_canMove)
        {
            _navAgent.SetDestination(pos);
        }
        else
        {
            throw new Exception("Monster Cannot Move");
        }
    }

    public void setIsSelected(bool val)
    {
        _isSelected = val;
        _selectedCursor.SetActive(true);
        if (_isSelected)
        {
            GameData.AddMonsterToSelected(this);
        }
    }

    public void toggleSelected()
    {
        _isSelected = !_isSelected;
        _selectedCursor.SetActive(!_selectedCursor.activeSelf);
        if (_isSelected)
        {
            GameData.AddMonsterToSelected(this);
        }
        else
        {
            GameData.RemoveMonsterFromSelected(this);
        }
    }

    public bool getIsSelected()
    {
        return _isSelected;
    }

    public void SetCanMove(bool val)
    {
        _canMove = val;
    }
}