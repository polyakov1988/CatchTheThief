using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _rate;

    private bool _isActive;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isActive)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 1, _rate * Time.deltaTime);
        }
        else if (_audioSource.volume != 0)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, 0, _rate * Time.deltaTime);
        }
        else if (_audioSource.volume == 0)
        { 
            _audioSource.Stop();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() && _isActive == false)
        {
            _isActive = true;
            
            _audioSource.Play();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _isActive = false;
        }
    }
}
