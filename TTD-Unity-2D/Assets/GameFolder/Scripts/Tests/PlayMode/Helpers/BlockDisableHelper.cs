using UnityEngine;

namespace TDDBeginner.Movement
{
    public class BlockDisableHelper : MonoBehaviour
    {
        Collider2D _collider2D;

        void Awake()
        {
            GetReference();
        }

        void OnValidate()
        {
            GetReference();
        }

        void GetReference()
        {
            _collider2D = GetComponent<Collider2D>();
        }

        public void SetDisableCollider()
        {
            _collider2D.enabled = false;
        }
    }
}