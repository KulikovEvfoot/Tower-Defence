using UnityEngine;

namespace TowerDefence.Core.Runtime.Towers.Rifle.Runtime
{
    public interface ITriggerObserver
    {
        void OnEnter(GameObject input);
        void OnExit(GameObject output);
    }
}