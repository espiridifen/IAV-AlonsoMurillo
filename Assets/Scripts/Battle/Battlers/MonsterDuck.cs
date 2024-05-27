using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDuck : Enemy
{
    [SerializeField] float _startPositionOffsetMax = 3f;
    [SerializeField] float _startPositionOffsetMin = 1f;

    [SerializeField] float _healAmount = 10f;
    [SerializeField] float _healCost = 30f;
    [SerializeField] float _buffCost = 30f;
    [SerializeField] float _debuffCost = 30f;
    float criticalMultiplier = 1.25f;
    float critChance = 0.1f;
    private StatModifier defendStanceModifier;

    public bool isDefending { get; private set; }

    protected override void Start()
    {
        //Offset bird to be off the ground at a random defined height.
        transform.position += new Vector3(0f, Random.Range(_startPositionOffsetMin, _startPositionOffsetMax) , 0f);
        base.Start();
        critChance = this.Critical;
        critDamageMultiplier = this.critDamageMultiplier;
    }

    protected void Heal()
    {
        if (CurrentMana >= _healCost)
        {
            UseMana(_healCost);
            RecoverHealth(_healAmount);
            OnDisplayAlert("Heal");
        }else OnDisplayAlert("Heal does not work!");
    }

    protected void Buff()
    {
        if (CurrentMana >= _buffCost)
        {
            UseMana(_buffCost);
            AddModifier(new StatModifier(100.0f, StatType.Critical, StatModifierType.Flat));
            critDamageMultiplier = 3.0f;
            OnDisplayAlert("Buff");
        }else OnDisplayAlert("Buff does not work!");
    }

    protected void Debuff()
    {
        if (CurrentMana >= _debuffCost)
        {
            UseMana(_debuffCost);
            AddModifier(new StatModifier(1.25f, StatType.PhysicalAttack, StatModifierType.PercentMultiply));
            OnDisplayAlert("Debuff");
        }else OnDisplayAlert("Debuff does not work!");
    }

    protected override void StartTurn()
    {
        invokeStartTurn();
        var action = enemyBrain.CalculateNextAction();


        //el codigo de cada uno

        switch (action)
        {
            case "Attack":
                Attack(PickRandomHero());
                break;
            case "Heal":
                Heal();
                break;
            case "Defend":
                Defend();
                break;
            case "Buff":
                Buff();
                break;
            case "Debuff":
                Debuff();
                break;
            default:
                Defend();
                break;
        }

        StartCoroutine(DelayEndTurn(1));
    }

    public virtual void Defend()
    {
        OnDisplayAlert("Defend");
        
        isDefending = true;
        AddModifier(defendStanceModifier);
       
        Debug.Log(gameObject.name + " defends.");
    }

    protected virtual void ResetDefence()
    {
        if (isDefending)
        {
            RemoveModifier(defendStanceModifier);
            isDefending = false;
            
        }
    }
}
