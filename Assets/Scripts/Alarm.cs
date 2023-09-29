using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSystem;

    private float _volumeChangeTime = 1f;
    private float _targetVolume;
    private Coroutine _activeCoroutine;

    private void Start()
    {
        _alarmSystem.volume = 0f;
    }

    public void Play()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _targetVolume = 1f;
        _alarmSystem.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void Stop()
    {
        if (_activeCoroutine != null)
        {
            StopCoroutine(_activeCoroutine);
        }

        _targetVolume = 0f;
        _activeCoroutine = StartCoroutine(ChangeVolume());
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
