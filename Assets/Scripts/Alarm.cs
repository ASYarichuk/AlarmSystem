using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSystem;

    private float _volumeChangeTime = 1f;
    private float _targetVolume;

    private void Start()
    {
        _alarmSystem.volume = 0;
    }

    public void Play()
    {
        _targetVolume = 1f;
        _alarmSystem.Play();
        StartCoroutine(ChangeVolume());
    }

    public void Stop()
    {
        _targetVolume = 0f;
        StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_alarmSystem.volume != _targetVolume)
        {
            _alarmSystem.volume = Mathf.MoveTowards(_alarmSystem.volume, _targetVolume, _volumeChangeTime * Time.deltaTime);
            yield return null;
        }
    }
}
