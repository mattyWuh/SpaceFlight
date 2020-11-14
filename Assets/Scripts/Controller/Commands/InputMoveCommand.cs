using System.Collections;
using UnityEngine;

public class InputMoveCommand : Command
{
    public AnimationCurve speed;

    private Rigidbody _rigidbody;
    private IMoveInput _move;
    private Coroutine _moveCoroutine;
    private Transform _transform;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _move = GetComponent<IMoveInput>();
        _transform = transform;
    }

    public override void Execute()
    {
        if (_moveCoroutine == null)
            _moveCoroutine = StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (_move.MoveDirection != Vector3.zero)
        {
            var time = (Time.fixedDeltaTime * speed.Evaluate(_move.MoveDirection.magnitude));
            _rigidbody.MovePosition(_transform.position + _move.MoveDirection * time);
            yield return null;
        }

        _moveCoroutine = null;
    }
}