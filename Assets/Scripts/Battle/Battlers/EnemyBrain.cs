using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicSystem;

public class EnemyBrain : MonoBehaviour
{
    public TextAsset fuzzyLogicData = null;
    public FuzzyLogic fuzzyLogic { get; private set; } = null;
    
    [SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        fuzzyLogic = FuzzyLogic.Deserialize(fuzzyLogicData.bytes, null);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void UpdateValues()
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

    void CalculateData()
    {
        UpdateValues();
        //recoger inferencias
            
    }
}
