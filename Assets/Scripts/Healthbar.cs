using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private Color _colorMaxHealth;
    [SerializeField] private Color _colorMinHealth;

    private Coroutine _fadeInJob;
    private float _drawSpeed = 15;

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
        _image.color = _colorMaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChenged += OnHealthChenged;
    }

    private void OnDisable()
    {
        _player.HealthChenged -= OnHealthChenged;
    }


    private IEnumerator FadeIn()
    {
        while  (_player.CurrentHealth != _slider.value) 
        {       
            _image.color = Color.Lerp(_colorMinHealth, _colorMaxHealth, _slider.value / _slider.maxValue);
            _slider.value = Mathf.MoveTowards(_slider.value, _player.CurrentHealth, Time.deltaTime* _drawSpeed);
            yield return null;
        }
    }

    private void OnHealthChenged()
    {
        if (_fadeInJob != null)
        {
            StopCoroutine(_fadeInJob);
        }

        _fadeInJob = StartCoroutine (FadeIn());     
    }
}
