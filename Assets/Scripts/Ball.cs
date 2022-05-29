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

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        // Set starting velocity by randomly selecting from pre-set possible X and Y velocities
        _rb.velocity = new Vector2(StartVelocity, StartVelocity);
    }

    // Called every physics tick (20/second)
    private void FixedUpdate()
    {
        // Continually reset the velocity to have the identical direction, but use the current velocityScale
        _rb.velocity = _rb.velocity.normalized * _velocityScale;
        
        // Increase velocity scale per frame overtime.
        _velocityScale += _velocityIncreasePerSecond * Time.deltaTime;

        Debug.Log($"Velocity: {_rb.velocity}");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Tell the wall we hit it
        if (!other.gameObject.TryGetComponent(out Wall wall)) return;
        else
        {
            wall.WallHit();
        }
    }

    // Slightly randomly offset velocity after collision
    private void OnCollisionExit2D(Collision2D other)
    {
        _rb.velocity = new Vector2(RandomOffsetVelocity(_rb.velocity.x), RandomOffsetVelocity(_rb.velocity.y));
    }

    // Return a random velocity slightly offset from the base collision velocity to create randomness
    private float RandomOffsetVelocity(float inputVelocity)
    {
        return Random.Range(inputVelocity - _velocityVariance, inputVelocity + _velocityVariance);
    }
}
