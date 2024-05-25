using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicSystem; // <-- esta

public class EnemyBrain : MonoBehaviour
{
    FuzzyLogic fuzzyLogic;
    Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        fuzzyLogic.evaluate = true;
        fuzzyLogic.GetFuzzificationByName("CurrentHP").value = enemy.CurrentHealth;
        fuzzyLogic.GetFuzzificationByName("CurrentMana").value = enemy.CurrentMana;
        fuzzyLogic.GetFuzzificationByName("Speed").value = enemy.Speed;
        fuzzyLogic.GetFuzzificationByName("Defense").value = enemy.Defense;
        fuzzyLogic.GetFuzzificationByName("CriticalChance").value = enemy.Critical;
        fuzzyLogic.GetFuzzificationByName("CritMultiplier").value = enemy.critDamage;
        fuzzyLogic.GetFuzzificationByName("EnemyHP").value = enemy.CurrentHealth;
        fuzzyLogic.GetFuzzificationByName("EnemyMana").value = enemy.CurrentMana;
        fuzzyLogic.GetFuzzificationByName("EnemySpeed").value = enemy.Speed;
        fuzzyLogic.GetFuzzificationByName("EnemyDefense").value = enemy.Defense;
        fuzzyLogic.GetFuzzificationByName("EnemyCriticalChance").value = enemy.Critical;
        fuzzyLogic.GetFuzzificationByName("EnemyCritMultiplier").value = enemy.critDamage;
    }
}
