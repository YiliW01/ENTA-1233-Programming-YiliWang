using UnityEngine;
using UnityEngine.Events;

public class TimedActivation : MonoBehaviour
{
    [SerializeField] private float _duration = 10f;
    [SerializeField] private bool _autoReset;
    [SerializeField] private bool _playOnEnable = true;

    [SerializeField] private UnityEvent _OnElapsed;
    private bool _isRunning;

    private float _timeRemaining;

    private void Update()
    {
        if (_isRunning == true)
        {
            _timeRemaining -= Time.deltaTime;
            if (_timeRemaining <= 0f)
            {
                Debug.Log($"timer done");
                _OnElapsed?.Invoke();
                StopTimer();
            }
        }
    }

    private void OnEnable()
    {
        _isRunning = true;
        _timeRemaining = _duration;
    }

    public void StartTimer() 
    { 
        _isRunning = true;
        _timeRemaining = _duration;
    }

    public void StopTimer() 
    { 
        _isRunning = false;
        _timeRemaining = _duration;
    }

    public void ResetTimer()
    {
        _timeRemaining = _duration;
    }
}
