using System;
using UnityEngine;

namespace Values
{
    [Serializable]
    public class AnimationFlag
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private string _key;

        private bool _value;

        public bool Active
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _animator.SetBool(_key, value);
            }
        }
    }
}