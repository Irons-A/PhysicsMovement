using UnityEngine;

public class FollowerMover : MonoBehaviour
{
    [SerializeField] private PlayerMover _target;
    [SerializeField] private float _speed = 4f;
    [SerializeField] private float _stopAtDistance = 2f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 targetDirection = _target.transform.position - transform.position;

        if (targetDirection.sqrMagnitude <= _stopAtDistance * _stopAtDistance)
        {
            targetDirection = Vector3.zero;
        }

        targetDirection.y = 0;
        targetDirection.Normalize();

        _rigidbody.velocity = new Vector3(
            targetDirection.x * _speed,
            _rigidbody.velocity.y,
            targetDirection.z * _speed);
    }
}
