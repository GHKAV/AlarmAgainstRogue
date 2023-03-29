using UnityEngine;
using UnityEngine.Events;

public class SigmalingZone : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached = new UnityEvent();

    public int IsReached { get; private set; }

    public event UnityAction Reached
    {
        add => _reached.AddListener(value);
        remove => _reached.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsReached = 1;
        _reached?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsReached = 0;
        _reached?.Invoke();
    }
}
