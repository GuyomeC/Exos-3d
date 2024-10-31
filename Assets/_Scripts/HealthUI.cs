using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    [SerializeField] Slider _slider;
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] EntityHealth _playerHealth;

    int CachedMaxHealth;

    private void Start()
    {
        CachedMaxHealth = _playerHealth.CurrentHealth;
        UpdateSlider(CachedMaxHealth);

        _playerHealth.OnHealthChanged += UpdateSlider;
    }

    public void UpdateSlider(int newHealthValue)
    {
        _slider.value = newHealthValue;
        _text.text = $"{newHealthValue} / {CachedMaxHealth}";
    }

    private void OnDestroy()
    {
        _playerHealth.OnHealthChanged -= UpdateSlider;
    }
}
