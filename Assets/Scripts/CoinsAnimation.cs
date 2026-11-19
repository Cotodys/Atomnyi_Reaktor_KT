using UnityEngine;

public class CoinsAnimation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0, 100f, 0);

    [Header("Hover settings")]
    [SerializeField] private float _hoverAmplitude = 0.25f;
    [SerializeField] private float _hoverSpeed = 2f;

    [Header("Spawn Bounds (3D)")]
    [SerializeField] private Vector2 _xBounds = new Vector2(-10f, 10f);
    [SerializeField] private Vector2 _zBounds = new Vector2(-10f, 10f);

    private Vector3 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);

        float newY = _startPosition.y + Mathf.Sin(Time.time * _hoverSpeed) * _hoverAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    public void SetStartPosition(Vector3 position)
    {
        _startPosition = position;
        transform.position = position;
    }

    public void RespawnRandomly()
    {
        float randomX = Random.Range(_xBounds.x, _xBounds.y);
        float randomZ = Random.Range(_zBounds.x, _zBounds.y);

        Vector3 newPos = new Vector3(randomX, _startPosition.y, randomZ);
        SetStartPosition(newPos);
    }
}
