using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDuck : Enemy
{
    [SerializeField] float _startPositionOffsetMax = 3f;
    [SerializeField] float _startPositionOffsetMin = 1f;

    [SerializeField] float _healAmount = 10f;
    [SerializeField] float _healCost = 30f;
    private StatModifier defendStanceModifier;

    public bool isDefending { get; private set; }

    protected override void Start()
    {
        //Offset bird to be off the ground at a random defined height.
        transform.position += new Vector3(0f, Random.Range(_startPositionOffsetMin, _startPositionOffsetMax) , 0f);
        base.Start();
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
