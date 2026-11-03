using UnityEngine;

public class CoinsAnimation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector3 _rotationSpeed = new Vector3(0, 100f, 0);

    [Header("Hover settings")]
    [SerializeField] private float _hoverAmplitude = 0.25f;
    [SerializeField] private float _hoverSpeed = 2f;

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
}
