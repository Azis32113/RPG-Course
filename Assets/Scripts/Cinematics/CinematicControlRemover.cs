using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


namespace RPG.Cinematics
{
    public class CinematicControlRemover : MonoBehaviour
    {

        void OnEnable()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        void OnDisable()
        {
            GetComponent<PlayableDirector>().played -= DisableControl;
            GetComponent<PlayableDirector>().stopped -= EnableControl;    
        }

        void DisableControl(PlayableDirector pd)
        {
            print("Disable Control");
        }

        void EnableControl(PlayableDirector pd)
        {
            print("Enable Control");
        }
    }
}
