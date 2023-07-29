namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IInputWatcher
    {
        public bool IsUsesMovementInput { get; }
        
        public bool IsUsesCameraInput { get; }

        public void SetIsUsesMovementInput(bool value);
        
        public void SetIsUsesCameraInput(bool value);
    }
}