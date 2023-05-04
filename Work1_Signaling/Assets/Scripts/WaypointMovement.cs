using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        if (_currentPoint >= _points.Length)
        {
            _currentPoint = 0;
        }

        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Point point))
        {
            _currentPoint++;
        }
    }
}