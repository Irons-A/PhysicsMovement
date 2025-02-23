using UnityEngine;

public class FollowerMover : MonoBehaviour
{
    [SerializeField] private PlayerMover _target;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _stopAtDistance = 2f;

    private Rigidbody _rigidbody;
    private Vector3 _offset;
    private Vector3 _targetPosition;
    private float _sqrLength;
    private bool _shouldMove = false;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_target != null)
        {
            _offset = _target.transform.position - transform.position;
            _sqrLength = _offset.sqrMagnitude;

            if (_sqrLength < _stopAtDistance * _stopAtDistance)
            {
                _shouldMove = false;

                _rigidbody.velocity = Vector3.zero;
            }
            else
            {
                _targetPosition = new Vector3(_offset.x, 0, _offset.z);

                _shouldMove = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_shouldMove)
        {
            _rigidbody.velocity += _targetPosition.normalized * _speed * Time.deltaTime;
        }
    }
}
