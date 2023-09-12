namespace Infrastructure.CodeBase.Services.InputService.Base
{
    public interface IInputWatcher
    {
        public bool IsUsesMovementInput { get; }
        
        public bool IsUsesCameraInput { get; }

        public void SetEnableIsUsesMovementInput();

        public void SetDisableIsUsesMovementInput();

        public void SetEnableIsUsesCameraInput();

        public void SetDisableIsUsesCameraInput();
    }
}