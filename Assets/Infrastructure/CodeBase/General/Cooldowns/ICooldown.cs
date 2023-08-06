using Cysharp.Threading.Tasks;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public interface ICooldown
    {
        public bool IsRecharged { get; }
        
        public UniTask StartCooldown();
    }
}