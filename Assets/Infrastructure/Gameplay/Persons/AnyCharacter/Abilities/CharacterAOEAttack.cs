using Infrastructure.Gameplay.Persons.Common.Abilities;

namespace Infrastructure.Gameplay.Persons.AnyCharacter.Abilities
{
    public class CharacterAOEAttack : IAbility
    {
        private int _damage;
        
        private ICooldown _cooldown;
        private IAttackColliders _attackColliders;

        public void Construct(int damage, 
            ICooldown cooldown, 
            IAttackColliders attackColliders)
        {
            _damage = damage;
            _cooldown = cooldown;
            _attackColliders = attackColliders;
        }

        private void Attack()
        {
            if (_cooldown.IsRecharged)
            {
                _attackColliders.Hit(_damage);
                
                _cooldown.StartCooldown();
            }
        }

        public void Use() => Attack();
    }
}