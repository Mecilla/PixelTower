using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP
{
    int _currentHealth;         // Oyuncunun mevcut can de�eri
    int _currentMaxHealth;      // Oyuncunun maksimum can de�eri

    // Property: Oyuncunun mevcut can de�erine eri�mek i�in kullan�l�r.
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

    // Property: Oyuncunun maksimum can de�erine eri�mek i�in kullan�l�r.
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

    // HP s�n�f�n�n yap�c� metodu. Oyuncunun ba�lang��ta sahip oldu�u can ve maksimum can de�erlerini belirler.
    public HP(int health, int maxHealth)
    {
        _currentHealth = health;
        _currentMaxHealth = maxHealth;
    }

    // Oyuncunun can�n� azaltan metot.
    public void DmgUnit(int dmgAmount)
    {
        // E�er oyuncunun can� 0'dan b�y�kse, verilen hasar� can�ndan d��er.
        if (_currentHealth > 0)
        {
            _currentHealth -= dmgAmount;
        }
    }

    // Oyuncunun can�n� art�ran metot.
    public void HealUnit(int healAmount)
    {
        // E�er oyuncunun can� maksimum can de�erinden k���kse, verilen iyile�me miktar�n� can�na ekler.
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
        }

        // E�er oyuncunun can� maksimum can de�erinden b�y�kse, can�n� maksimum can de�erine e�itler.
        if (_currentHealth > _currentMaxHealth)
        {
            _currentHealth = _currentMaxHealth;
        }
    }
}
