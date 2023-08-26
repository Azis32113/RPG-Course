using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;

        private Fighter fighter;
        private Health health;
        private GameObject player;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            player = GameObject.FindWithTag("Player");

        }

        private void Update()
        {
            if (health.IsDead()) return;

            if (InAttackRangeOfPlayer() && fighter.CanAttack(player))
            {
                fighter.Attack(player);
            }

            else
            {
                fighter.Cancel();
            }

        }

        private bool InAttackRangeOfPlayer()
        {
            float DistanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            return DistanceToPlayer <= chaseDistance;
        }
    }    
}
