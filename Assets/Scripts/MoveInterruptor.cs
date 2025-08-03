using UnityEngine;

public class MoveInterruptor : MonoBehaviour
{
    [SerializeField] private Transform _object;
    [SerializeField] private float _moveSpeed;
    private AudioSource _audio;
    private Vector3 _initialPosition;
    private bool _restore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _initialPosition = _object.position;
        _restore = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_restore && _initialPosition != _object.position)
        {
            _object.position = Vector3.MoveTowards(_object.position, _initialPosition, Mathf.Abs(_moveSpeed) * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            _audio.Play();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            _object.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
            _restore = false;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            _audio.Stop();
            _restore = true;
        }
    }
}
