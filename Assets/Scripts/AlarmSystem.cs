using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSystem;

    private float _maxVolume = 1;
    private float _currentVolume = 0;
    private float _volumeChangeTime = 1f;

    [SerializeField] private bool isEnabled = false;

    private void Update()
    {
        if (isEnabled)
        {
            _alarmSystem.volume = Mathf.MoveTowards(_currentVolume, _maxVolume, _volumeChangeTime * Time.deltaTime);

            if (_currentVolume < _maxVolume)
            {
                _currentVolume += _volumeChangeTime * Time.deltaTime;
            }
        }
        else
        {
            _alarmSystem.volume = Mathf.MoveTowards(_currentVolume, _maxVolume, _volumeChangeTime * Time.deltaTime);

            if(_currentVolume > 0)
            {
                _currentVolume -= _volumeChangeTime * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<StarterAssets.ThirdPersonController>(out StarterAssets.ThirdPersonController player))
        {
            if (isEnabled == false)
            {
                isEnabled = true;
                _alarmSystem.Play();
            }
            else
            {
                isEnabled = false;
            }
        }
    }
}
