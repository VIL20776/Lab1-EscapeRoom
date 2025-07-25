using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private bool _resetLevel = false;
    private Vector3 _initialPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _initialPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            if (_resetLevel)
                SceneManager.LoadScene("SampleScene");
            else
                gameObject.transform.position = _initialPosition;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            _menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            GetComponentInChildren<FirstPersonLook>().enabled = false;
            GetComponentInChildren<FirstPersonMovement>().enabled = false;
        }
    }
}
