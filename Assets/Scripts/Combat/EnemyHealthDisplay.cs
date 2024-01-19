using UnityEngine;
using TMPro;
using System;

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

            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}%", fighter.GetTarget().GetPercentage());

        }
    }
}