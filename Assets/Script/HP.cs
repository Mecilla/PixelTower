using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
    int _currentHealth;         // Oyuncunun mevcut can deðeri
    int _currentMaxHealth;      // Oyuncunun maksimum can deðeri

    // Property: Oyuncunun mevcut can deðerine eriþmek için kullanýlýr.
    public int Health
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = value;
        }
    }

    // Property: Oyuncunun maksimum can deðerine eriþmek için kullanýlýr.
    public int MaxHealth
    {
        get
        {
            return _currentMaxHealth;
        }
        set
        {
            _currentMaxHealth = value;
        }
    }

    // HP sýnýfýnýn yapýcý metodu. Oyuncunun baþlangýçta sahip olduðu can ve maksimum can deðerlerini belirler.
    public HP(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Oyuncunun canýný azaltan metot.
    public void DmgUnit(int dmgAmount)
    {
        // Eðer oyuncunun caný 0'dan büyükse, verilen hasarý canýndan düþer.
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    // Oyuncunun canýný artýran metot.
    public void HealUnit(int healAmount)
    {
        // Eðer oyuncunun caný maksimum can deðerinden küçükse, verilen iyileþme miktarýný canýna ekler.
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        // Eðer oyuncunun caný maksimum can deðerinden büyükse, canýný maksimum can deðerine eþitler.
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
