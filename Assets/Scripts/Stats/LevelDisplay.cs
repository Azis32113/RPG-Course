using UnityEngine;
using TMPro;
using System;

namespace RPG.Stats
{    
    class LevelDisplay : MonoBehaviour 
    {
        BaseStats baseStats;

        void Awake() {
            baseStats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
        }

        void Update() {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}", baseStats.GetLevel());
        }
    }
}