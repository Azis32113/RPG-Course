using UnityEngine;
using TMPro;
using System;

namespace RPG.Attributes
{    
    class HealthDisplay : MonoBehaviour 
    {
        Health health;

        void Awake() {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
        }

        void Update() {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0} / {1:0}", health.GetHealthPoints(), health.GetMaxHealthPoints());
        }
    }
}