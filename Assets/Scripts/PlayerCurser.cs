using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCurser : MonoBehaviour
{
    [SerializeField] private GameObject _curser;

    private GameObject _currentlyHit;

    [SerializeField]
    private GameObject _detailsPanel;

    private void Update()
    {
        UpdateCurserPos();
        SelectMonsters();
    }

    private void SelectMonsters()
    {
        if (_currentlyHit.CompareTag("Monster"))
        {
            var controller = _currentlyHit.GetComponentInParent<MonsterController>();
            if (Input.GetMouseButtonDown(0))
            {
                controller.toggleSelected();
            }
        }
    }

    private void UpdateCurserPos()
    {
        // Cast a ray from screen point
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Save the info
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 dir = hit.point - transform.position;
            _curser.transform.position = hit.point;

            _currentlyHit = hit.collider.gameObject;
        }
    }

    public Transform getCurserPos()
    {
        return _curser.transform;
    }
}