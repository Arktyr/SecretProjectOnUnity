namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public class InputWatcher : IInputWatcher
    {
        public bool IsUsesMovementInput { get; private set; }
        
        public bool IsUsesCameraInput { get; private set; }

        public void SetEnableIsUsesMovementInput() => IsUsesMovementInput = true;
        
        public void SetDisableIsUsesMovementInput() => IsUsesMovementInput = false;

        public void SetEnableIsUsesCameraInput() => IsUsesCameraInput = true;
        
        public void SetDisableIsUsesCameraInput() => IsUsesCameraInput = false;
    }
}