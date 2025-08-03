using UnityEngine;

public class InterruptorAction : MonoBehaviour
{
    [SerializeField] private GameObject _wall;
    private AudioSource _audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            _audio.Play();
            _wall.SetActive(false);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Cube") || other.CompareTag("Player"))
        {
            _wall.SetActive(true);
        }
    }
}
