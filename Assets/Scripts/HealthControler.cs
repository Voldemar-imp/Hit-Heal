using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _damage = -10;
    private float _heal = 10;

    public void GetDamage()
    {
        _player.TakeDamage(_damage);
    }

    public void GetHeal()
    {
        _player.TakeDamage(_heal);
    }
}
