using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider _healthBarSlider;
    public Slider HealthBarSlider => _healthBarSlider;
    private float _maxHealth;
    public float MaxHealth 
    { 
        get => _maxHealth; 
        set => _maxHealth = value; 
    }
    public void Initialize(float maxValue)
    {
        _healthBarSlider = GetComponent<Slider>();
        _maxHealth = maxValue;
        _healthBarSlider.maxValue = maxValue;
    }
    public void SetValue(float value)
    {
        if(value >= 0 && value <= _maxHealth)
        {
            _healthBarSlider.value = value ;
        }
    }
}