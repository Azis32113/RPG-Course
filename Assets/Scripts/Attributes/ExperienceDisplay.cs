using UnityEngine;
using TMPro;
using System;

namespace RPG.Attributes
{    
    class ExperienceDisplay : MonoBehaviour 
    {
        Experience experience;

        void Awake() {
            experience = GameObject.FindWithTag("Player").GetComponent<Experience>();
        }

        void Update() {
            GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}", experience.GetPoints());
        }
    }
}