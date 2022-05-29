using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _velocityScale;
    [SerializeField] private float _velocityIncreasePerSecond;

    [SerializeField] private float _velocityVariance;

    private Rigidbody2D _rb;

    [SerializeField] private float[] _startingVelocityValues;
    public float StartVelocity { get => _startingVelocityValues[Random.Range(0, _startingVelocityValues.Length)]; }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.velocity = new Vector2(StartVelocity, StartVelocity);
    }

    private void FixedUpdate()
    {
        _rb.velocity = _rb.velocity.normalized * _velocityScale;
        _velocityScale += _velocityIncreasePerSecond * Time.deltaTime;

        Debug.Log($"Velocity: {_rb.velocity}");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _rb.velocity = new Vector2(RandomOffsetVelocity(_rb.velocity.x), RandomOffsetVelocity(_rb.velocity.y));
    }

    private float RandomOffsetVelocity(float inputVelocity)
    {
        return Random.Range(inputVelocity - _velocityVariance, inputVelocity + _velocityVariance);
    }
}
