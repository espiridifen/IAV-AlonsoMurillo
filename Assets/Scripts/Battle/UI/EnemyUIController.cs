using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//test
public class EnemyUIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _nameText;
    [SerializeField] Slider _timerBar;
    [SerializeField] Slider _manaBar;
    [SerializeField] Slider _healthBar;
    [SerializeField] TextMeshProUGUI _healthText;
    [SerializeField] TextMeshProUGUI _manaText;
    private float _maxHealth;
    private float _maxMana;
    private Enemy _enemy;

    private void OnEnable()
    {
        if (_enemy != null)
            Initialize(_enemy);
    }

    private void OnDisable()
    {
        if (_enemy != null)
        {
            _enemy.OnHealthChanged -= UpdateHealth;
            _enemy.OnManaChanged -= UpdateMana;
            _enemy.OnTurnTimeChanged -= UpdateTurnTimer;
        }
    }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _nameText.SetText(enemy.Name);

        _maxHealth = enemy.MaxHealth;
        _healthBar.maxValue = _maxHealth;
        UpdateHealth(enemy.CurrentHealth);

        _maxMana = enemy.MaxMana;
        _manaBar.maxValue = _maxMana;
        UpdateMana(enemy.CurrentMana);

        _timerBar.maxValue = 100;
        gameObject.SetActive(true);

        enemy.OnHealthChanged += UpdateHealth;
        enemy.OnTurnTimeChanged += UpdateTurnTimer;
        enemy.OnManaChanged += UpdateMana;
    }

    private void UpdateHealth(float health)
    {
        _healthBar.value = Mathf.Clamp(health, 0, _maxHealth);
        _healthText.SetText(health + " / " + _maxHealth);
    }

    private void UpdateMana(float mana)
    {
        _manaBar.value = Mathf.Clamp(mana, 0, _maxMana);
        _manaText.SetText(mana + " / " + _maxMana);
    }

    private void UpdateTurnTimer(float time)
    {
        _timerBar.value = Mathf.Clamp(time, 0, 100);
    }
}
