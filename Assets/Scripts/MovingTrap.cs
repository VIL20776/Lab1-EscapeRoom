using System;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _amplitude;
    [SerializeField] private float _speed;
    [SerializeField] private float _offset;
    private float _time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += _speed * Time.deltaTime;
        gameObject.transform.position += _direction * _amplitude * MathF.Sin(_time + _offset);
    }
}
