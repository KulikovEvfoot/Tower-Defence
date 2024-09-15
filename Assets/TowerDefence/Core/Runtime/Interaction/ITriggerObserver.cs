using UnityEngine;

namespace TowerDefence.Core.Runtime.Interaction
{
    public interface ITriggerObserver
    {
        void OnEnter(GameObject input);
        void OnExit(GameObject output);
    }
}