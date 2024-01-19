using UnityEngine;

namespace RPG.Attributes
{
    class Experience : MonoBehaviour {
        [SerializeField] float experiencePoints = 0;

        public void GainExperience(float experience)
        {
            experiencePoints += experience;
        }
    }
}