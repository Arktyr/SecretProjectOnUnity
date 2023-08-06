using Infrastructure.Gameplay.Persons.Common.Injuring;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public interface IAttack
    {
        public void Hit(int damage, IDamageNotifier damageNotifier);
    }
}