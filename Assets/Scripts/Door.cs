using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _activateDistance;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _endPosition;

    private Vector3 _startPosition;
    private float _timer;
    
    private void Start()
    {
        _startPosition = transform.position;
        _endPosition += transform.position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _target.position) < _activateDistance)
        {
            _timer = Mathf.Clamp01(_timer + Time.deltaTime * _speed);
            transform.position = Vector3.Slerp(_startPosition, _endPosition, _timer);
        }
        else
        {
            _timer = Mathf.Clamp01(_timer - Time.deltaTime * _speed);
            transform.position = Vector3.Slerp(_startPosition, _endPosition, _timer);
        }
    }
}
