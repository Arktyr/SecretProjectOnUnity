using Cysharp.Threading.Tasks;

namespace Infrastructure.Gameplay.Persons.Common.Abilities
{
    public class Cooldown : ICooldown
    {
        private int _delay;
        
        public bool IsRecharged { get; private set; }

        public void Construct(int delay)
        {
            _delay = delay;

            IsRecharged = true;
        }
        
        public async UniTask StartCooldown()
        {
            IsRecharged = false;
            
            int delayInSeconds = _delay * 1000;
            await UniTask.Delay(delayInSeconds);

            IsRecharged = true;
        }
    }
}