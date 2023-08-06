using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public class Attack : IAttack
    {
        public void Hit(int damage, IDamageNotifier damageNotifier) => damageNotifier.TakeDamage(damage);
    }
}