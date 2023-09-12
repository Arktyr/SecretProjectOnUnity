using Cysharp.Threading.Tasks;

namespace Infrastructure.CodeBase.General.StateMachine.Interfaces
{
    public interface IExitableState
    {
        void Exit();
    }
}