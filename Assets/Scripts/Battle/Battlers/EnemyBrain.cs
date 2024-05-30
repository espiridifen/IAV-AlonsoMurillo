using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicSystem;
using System.Linq;
using UnityEditor.SearchService;
using System;

public class EnemyBrain : MonoBehaviour
{
    public TextAsset fuzzyLogicData = null;
    public FuzzyLogic fuzzyLogic { get; private set; } = null;

    //Struct para almacenar las acciones y los valores post fuzzi
    private struct Action : IComparable<Action>
    {
        public float value;
        public string name;

        public Action(string name, float value)
        {
            this.name = name;
            this.value = value;
        }
        public static bool operator >(Action a, Action b)
        {
            return a.value > b.value;
        }
        public static bool operator <(Action a, Action b)
        {
            return a.value < b.value;
        }

        public int CompareTo(Action other)
        {
            return this < other ? 1 : -1;
        }
    }

    
    //set de acciones para tenerlas ordenadas de mayor a menor, y asi sacar la mas prioritaria
    SortedSet<Action> actions; 

    bool isTurn = false;
    
    [SerializeField] Enemy enemy;

    public Hero target { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        fuzzyLogic = FuzzyLogic.Deserialize(fuzzyLogicData.bytes, null);
        actions = new SortedSet<Action>();

    }

    public string CalculateNextAction()
    {
        SelectTarget();
        UpdateValues();
        CalculateData();
        return actions.First().name;
    }

    private void SelectTarget()
    {
        //random, se podría extender la lógica difusa para elegir el objetivo, pero el sistema de FuzzyLogic no es muy escalable
        target = BattleManager.Instance.heroes[UnityEngine.Random.Range(0, BattleManager.Instance.heroes.Count)];
    }

    void UpdateValues()
    {
        fuzzyLogic.evaluate = true;
        fuzzyLogic.GetFuzzificationByName("CurrentHP").value = enemy.CurrentHealth;
        fuzzyLogic.GetFuzzificationByName("CurrentMana").value = enemy.CurrentMana;
        fuzzyLogic.GetFuzzificationByName("Speed").value = enemy.Speed;
        fuzzyLogic.GetFuzzificationByName("Defense").value = enemy.Defense;
        fuzzyLogic.GetFuzzificationByName("CriticalChance").value = enemy.Critical*100;
        fuzzyLogic.GetFuzzificationByName("CritMultiplier").value = enemy.critDamage*100;
        fuzzyLogic.GetFuzzificationByName("EnemyHP").value = target.CurrentHealth;
        fuzzyLogic.GetFuzzificationByName("EnemyMana").value = target.CurrentMana;
        fuzzyLogic.GetFuzzificationByName("EnemySpeed").value = target.Speed;
        fuzzyLogic.GetFuzzificationByName("EnemyDefense").value = target.Defense;
        fuzzyLogic.GetFuzzificationByName("EnemyCriticalChance").value = target.Critical*100;
        fuzzyLogic.GetFuzzificationByName("EnemyCritMultiplier").value = target.critDamage;

    }

    void CalculateData()
    {
        UpdateValues();
        //recoger inferencias
        //valor de 0 a 1
        for(int i = 0; i < fuzzyLogic.NumberInferences(); i++)
        {
            var action = new Action(fuzzyLogic.GetInference(i).name, fuzzyLogic.GetInference(i).Output());
            if (action.name == "Defend" || action.name == "Attack" || action.name == "Heal" || action.name == "Buff" || action.name == "Debuff") //solo las inferencias que nos interesan
            {
                actions.Add(action);
            }
            
        }
        var first = actions.First<Action>();
        //valor a devolver
        //action.First();
            
    }

    

   
}
