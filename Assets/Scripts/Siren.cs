using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Siren : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _rate;
    [SerializeField] private float _volumeMin;
    [SerializeField] private float _volumeMax;

    public bool IsActive { get; private set; }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (IsActive)
        {
            ChangeVolumeToTarget(_volumeMax);
        }
        else if (_audioSource.volume != 0)
        {
            ChangeVolumeToTarget(_volumeMin);
        }
        else if (_audioSource.volume == 0)
        { 
            _audioSource.Stop();
        }
    }

    public void Activate()
    {
        IsActive = true;
        _audioSource.Play();
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    private void ChangeVolumeToTarget(float target)
    {
        _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _rate * Time.deltaTime);
    }
}
