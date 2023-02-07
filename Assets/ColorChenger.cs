using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorChenger : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Slider _slider;
    [SerializeField] private Color _colorMaxHealth;
    [SerializeField] private Color _colorMinHealth;

    public void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        _image.color = Color.Lerp(_colorMinHealth, _colorMaxHealth, _slider.value/_slider.maxValue);
    }
}
