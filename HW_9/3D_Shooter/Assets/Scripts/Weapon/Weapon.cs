using Player;
using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] protected PlayerInput PlayerInput;

        protected abstract void Attack();
    }
}
