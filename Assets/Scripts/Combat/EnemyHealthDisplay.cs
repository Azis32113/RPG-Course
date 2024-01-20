using UnityEngine;
using TMPro;
using System;
using RPG.Attributes;

namespace RPG.Combat
{    
    class EnemyHealthDisplay : MonoBehaviour 
    {
        Fighter fighter;

        void Awake() {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
        }

        void Update() {
            if (fighter.GetTarget() == null) {
                GetComponent<TextMeshProUGUI>().text = "N/A";
                return;
            }
            Health health = fighter.GetTarget();
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0} / {1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());

        }
    }
}