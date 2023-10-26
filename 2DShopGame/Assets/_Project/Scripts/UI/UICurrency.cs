using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class UICurrency : UIScreenView
{
    private TMP_Text _currencyLabel;

    private void Start()
    {
        _currencyLabel = GetComponent<TMP_Text>();
        UpdateCurrency();
    }

    public void UpdateCurrency()
    {
        _currencyLabel.text = $"Gold: {AppManager.Player.Currency}";
    }
}
