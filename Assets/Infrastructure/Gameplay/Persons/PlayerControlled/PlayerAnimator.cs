using UnityEngine;

namespace Infrastructure.Gameplay.Persons.AnyCharacter
{
    public class PlayerAnimator
    {
        private Animator _animator;
        
        private readonly int IsRun = Animator.StringToHash("IsRun");
        private readonly int IsIdle = Animator.StringToHash("IsIdle");

        public void Construct(Animator animator)
        {
            _animator = animator;
        }

        public void SetRunAnimation(bool isRun) => _animator.SetBool(IsRun, isRun);

        public void SetIdleAnimation(bool isIdle) => _animator.SetBool(IsIdle, isIdle);
    }
}