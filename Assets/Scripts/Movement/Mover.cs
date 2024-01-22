using UnityEngine;
using UnityEngine.AI;

using RPG.Core;
using RPG.Saving;
using RPG.Attributes;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction, ISaveable
    {
        [SerializeField] float maxSpeed = 6f;

        NavMeshAgent navMeshAgent;
        Health health;

        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();    
            health = GetComponent<Health>();
        } 
        
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination, float speedFraction)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination, speedFraction);
        }

        public void MoveTo(Vector3 destination, float speedFraction)
        {
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            GetComponent<Animator>().SetFloat("forwardSpeed", speed);

        }

        public object CaptureState()
        {
            return new SerializableVector3(transform.position);
        }

        public void RestoreState(object state)
        {
            SerializableVector3 position = (SerializableVector3)state;
            navMeshAgent.enabled = false;
            transform.position = position.ToVector();
            navMeshAgent.enabled = true;

            // navMeshAgent.Move(position.ToVector());

            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        // SAVING MULTIPLE PARAMETERS USING STRUCT
        // [System.Serializable]
        // struct MoverSaveData
        // {
        //     public SerializableVector3 position;
        //     public SerializableVector3 rotation;
        // }

        // public object CaptureState()
        // {
        //     MoverSaveData data = new MoverSaveData();
        //     data.position = new SerializableVector3(transform.position);
        //     data.rotation = new SerializableVector3(transform.eulerAngles);

        //     return data;
        // }

        // public void RestoreState(object state)
        // {
        //     MoverSaveData data = (MoverSaveData)state;
        //     GetComponent<NavMeshAgent>().enabled = false;
        //     transform.position = data.position.ToVector();
        //     transform.eulerAngles = data.rotation.ToVector();
        //     GetComponent<NavMeshAgent>().enabled = true;
        // }
        

        // SAVING MULTIPLE PARAMETERS USING DICTIONARY
        // public object CaptureState()
        // {
        //     Dictionary<string, object> data = new Dictionary<string, object>();
        //     data["position"] = new SerializableVector3(transform.position);
        //     data["rotation"] = new SerializableVector3(transform.eulerAngles);

        //     return data;
        // }

        // public void RestoreState(object state)
        // {
        //     Dictionary<string, object> data = (Dictionary<string, object>)state;
        //     GetComponent<NavMeshAgent>().enabled = false;
        //     transform.position = ((SerializableVector3)data["position"]).ToVector();
        //     transform.eulerAngles = ((SerializableVector3)data["rotation"]).ToVector();
        //     GetComponent<NavMeshAgent>().enabled = true;
        // }  
    }
}
