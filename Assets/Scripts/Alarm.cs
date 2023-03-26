using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField]private float _timeIncrease;

    private SigmalingZone _sigmalingZone;
    private AudioSource _audioSource;

    private float _targetVolume;

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
        if (_sigmalingZone.IsReached)
        {
            _targetVolume = 1;
            StartCoroutine(ChangeVolume());
        }
        else
        {
            _targetVolume = 0;
            StartCoroutine(ChangeVolume());
        }
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _timeIncrease * Time.deltaTime);
            yield return null;
        }
    }
}
