namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public class InputWatcher : IInputWatcher
    {
        public bool IsUsesMovementInput { get; private set; }
        
        public bool IsUsesCameraInput { get; private set; }
        
        public void SetIsUsesMovementInput(bool value) => IsUsesMovementInput = value;

        public void SetIsUsesCameraInput(bool value) => IsUsesCameraInput = value;
    }
}