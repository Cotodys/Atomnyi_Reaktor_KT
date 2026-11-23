using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Magazine : MonoBehaviour
{


    [Header("UI")]
    [SerializeField] private Image _buttonImage;

    [Header("Color")]
    [SerializeField] private Color _activeColor = Color.green;
    [SerializeField] private Color _inactiveColor = Color.red;

    [Header("Juice Animation Settings")]
    [SerializeField] private float _punchScaleAmount = 0.2f;
    [SerializeField] private float _animationDuration = 0.25f;

    private bool _isMagnetActive = false;
    private float _radius = 1.1f;
    private Vector3 originalScale;
    private Coroutine punchCoroutine;

    public bool IsMagnetActive => _isMagnetActive;
    public float Radius => _radius;

    void Start()
    {
        originalScale = transform.localScale;

            _buttonImage.color = _inactiveColor;
    }

    public void BuyMagnetUpgrade()
    {
        _isMagnetActive = !_isMagnetActive;

        if (_buttonImage != null)
        {
            _buttonImage.color = _isMagnetActive ? _activeColor : _inactiveColor;
        }

        if (punchCoroutine != null)
        {
            StopCoroutine(punchCoroutine);
        }
        punchCoroutine = StartCoroutine(PunchScaleRoutine());

        Debug.Log($"Магнит активен: {_isMagnetActive}");
/*
        if (_inactiveColor )
        {

        }*/
    }






    private IEnumerator PunchScaleRoutine() //корутину сделала полностью ИИ.
    {
        float elapsedTime = 0f;
        Vector3 targetScale = originalScale * (1f + _punchScaleAmount);

        while (elapsedTime < _animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _animationDuration;

            float sinScale = Mathf.Sin(progress * Mathf.PI);

            transform.localScale = Vector3.Lerp(originalScale, targetScale, sinScale);

            yield return null;
        }
        transform.localScale = originalScale;
    }
}

