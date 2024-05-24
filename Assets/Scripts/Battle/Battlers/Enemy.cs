using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Battler
{
    protected List<Hero> heroes;

    public delegate void StartTurnEventHandler(Enemy enemy);
    public event StartTurnEventHandler OnStartTurn;
    public delegate void EndTurnEventHandler();
    public event EndTurnEventHandler OnEndTurn;

    //Events for UI
    public delegate void HealthEventHandler(float health);
    public event HealthEventHandler OnHealthChanged;
    public delegate void TurnTimerEventHandler(float time);
    public event TurnTimerEventHandler OnTurnTimeChanged;
    public delegate void ManaEventHandler(float mana);
    public event ManaEventHandler OnManaChanged;
    protected override void Start()
    {
        base.Start();
        heroes = BattleManager.Instance.heroes;
    }

    protected virtual void Attack(Hero hero)
    {
        Debug.Log(gameObject.name + " attacked " + hero.gameObject.name);
        OnDisplayAlert("Attack");
        hero.TakeDamage(CalculateDamage(baseDamageMultiplier));
        StartCoroutine(DelayEndTurn(1));
        //EndTurn();
    }

    protected virtual Hero PickRandomHero()
    {
        int index = Random.Range(0, heroes.Count);
        Hero hero = heroes[index];
        return hero;
    }

    protected override void StartTurn()
    {
        OnStartTurn?.Invoke(this);
        Attack(PickRandomHero());
        //FuzzyBrain.SelectAction(this);
    }

    protected override void EndTurn()
    {
        turnTimer = 0;
        OnEndTurn?.Invoke();
    }

    protected void OnDestroy()
    {
        if (FindObjectOfType<BattleManager>())
        {
            BattleManager.OnActiveTurnChanged -= ToggleTurnTimer;
        }
    }

    public IEnumerator DelayEndTurn(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        EndTurn();
    }

    public void UpdateManaUI()
    {
        OnManaChanged?.Invoke(currentMana);
    }

    public void UpdateHealthUI()
    {
        OnHealthChanged?.Invoke(currentHealth);
    }
    public void UpdateTimeUI()
    {
        OnTurnTimeChanged?.Invoke(turnTimer);
    }

}
