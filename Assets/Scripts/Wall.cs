using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [Header("Color Settings")]
    [SerializeField] private Color _baseColor;
    [SerializeField] private Color _hitColor;
    [SerializeField] private float _flashDuration;

    private BoxCollider2D _collider;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        // Get Component References
        _collider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        // Match sprite color to set BaseColor
        _spriteRenderer.color = _baseColor;
    }

    // Enable/Disable Wall without deactivating wall component
    public void ToggleActive(bool active)
    {
        // Chained Declaration to Enable/Disable Sprite Renderer and Collider
        _spriteRenderer.enabled = _collider.enabled = active;
    }

    public void WallHit()
    {
        StartCoroutine(ColorFlash());
    }

    // Flash wall to HitColor when ball hits it
    private IEnumerator ColorFlash()
    {
        _spriteRenderer.color = _hitColor;
        yield return new WaitForSecondsRealtime(_flashDuration);
        _spriteRenderer.color = _baseColor;
    }
}
