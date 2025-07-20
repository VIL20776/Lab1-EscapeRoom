using System;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    [SerializeField] Vector3 _direction;
    [SerializeField] float _amplitude;
    [SerializeField] float _speed;
    [SerializeField] float _offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += _direction * _amplitude * MathF.Sin(_speed * Time.time + _offset);
    }
}
