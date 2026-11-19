using System;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldText;

    private void OnEnable()
    {
        PlayerController.CoinGet += OnCoinGet;
    }

    private void OnDisable()
    {
        PlayerController.CoinGet -= OnCoinGet;
    }

    private void OnCoinGet(int coins)
    {
        _goldText.text = "Баланс: " + coins.ToString();
    }
}
