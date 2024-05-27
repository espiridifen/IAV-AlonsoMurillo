using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FuzzyLogicSystem;
using System.Linq;

public class EnemyBrain : MonoBehaviour
{
    public TextAsset fuzzyLogicData = null;
    public FuzzyLogic fuzzyLogic { get; private set; } = null;

    //Struct para almacenar las acciones y los valores post fuzzi
    private struct Action
    {
        public string name;
        public float value;

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
    }

    
    //set de acciones para tenerlas ordenadas de mayor a menor, y asi sacar la mas prioritaria
    HashSet<Action> action; 

    bool isTurn = false;
    
    [SerializeField] Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        fuzzyLogic = FuzzyLogic.Deserialize(fuzzyLogicData.bytes, null);

    }

    // Update is called once per frame
    void Update()
    {
        if (isTurn)
        {
            UpdateValues();
            CalculateData();
            doAction();
        }
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
        //valor de 0 a 1
        for(int i = 0; i < fuzzyLogic.NumberInferences(); i++)
        {
            action.Add(new Action(fuzzyLogic.GetInference(i).name, fuzzyLogic.GetInference(i).Output()));
        }
        //valor a devolver
        //action.First();
            
    }

    void doAction()
    {

        switch (action.First().name)
        {
            case "Attack":
                //hacer ataque
                break;
            case "Defend":
                //hacer defensa
                break;
            case "Heal":
                //hacer curacion
                break;
            case "Buff":
                //hacer buff
                break;
            case "Debuff":
                //hacer debuff
                break;
            case "Flee":
                //hacer huida
                break;
            default:
                break;
        }

        isTurn = false;
    }

   
}
