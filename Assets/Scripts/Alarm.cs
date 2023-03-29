using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SigmalingZone))]

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _timeIncrease;

    private SigmalingZone _sigmalingZone;
    private AudioSource _audioSource;
    private Coroutine _changeVolumeCoroutine;

    private void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _sigmalingZone = GetComponent<SigmalingZone>();
        _sigmalingZone.Reached += StartCoroutineChangeVolume;
    }

    private void OnDisable()
    {
        _sigmalingZone.Reached -= StartCoroutineChangeVolume;
    }

    private void StartCoroutineChangeVolume()
    {
        if (_changeVolumeCoroutine != null)
        {
            StopCoroutine(_changeVolumeCoroutine);
        }

        _changeVolumeCoroutine = StartCoroutine(ChangeVolume());
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _sigmalingZone.IsReached)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _sigmalingZone.IsReached, _timeIncrease * Time.deltaTime);
            yield return null;
        }
    }
}
