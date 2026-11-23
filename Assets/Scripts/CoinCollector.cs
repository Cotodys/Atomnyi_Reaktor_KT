using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Magazine _magazine;
    [SerializeField] public SphereCollider SphereColliderMagnite;
    public static event Action<int> CoinGet;
    private int _coins = 0;
    private float _radius = 1.1f;
    private float _maxRadius = 3f;

    public void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Coin"))
        {
            _coins += 1;
            CoinGet?.Invoke(_coins);

            if (col.TryGetComponent(out CoinsAnimation coin))
            {
                coin.RespawnRandomly();
            }
        }
    }

    public void Update()
    {
        if (_magazine.IsMagnetActive == true)
        {
            SphereColliderMagnite.radius = _maxRadius;
        }

        if (_magazine.IsMagnetActive == false)
        {
            SphereColliderMagnite.radius = _radius;
        }
    }
}
