using System;
using UnityEngine;

namespace RPG.Core
{
    class PersistentObjectSpawner : MonoBehaviour 
    {
        [SerializeField] GameObject persistentObjectPrefab;

        static bool hasSpawned = false;

        void Awake() {
            if (hasSpawned) return;

            SpawnPersistentObjects();
            hasSpawned = true;
        }

        private void SpawnPersistentObjects()
        {
            GameObject persistentPobject = Instantiate(persistentObjectPrefab);
            DontDestroyOnLoad(persistentPobject);
        }
    }
}