using System;
using Infrastructure.CodeBase.Services.UnSubscribe;
using Infrastructure.Gameplay.UI.Animations;
using Infrastructure.Gameplay.UI.Animations.ButtonAnimation.ButtonAnimation;
using UnityEngine.EventSystems;

namespace Infrastructure.CodeBase.UI.Buttons
{
    public class SelectableButton : IDisposable
    {
        private BaseButton _baseButton;
        private ISelectableButtonAnimation _selectableButtonAnimation;

        private readonly IDisposableService _disposableService;

        public SelectableButton(IDisposableService disposableService)
        {
            _disposableService = disposableService;
        }

        public void Construct(BaseButton baseButton,
            ISelectableButtonAnimation selectableButtonAnimation)
        {
            _baseButton = baseButton;
            _selectableButtonAnimation = selectableButtonAnimation;

            SubscribeToEvents();
        }

        private void OnPointerEnter(PointerEventData pointerEventData) => 
            _selectableButtonAnimation.StartAnimation(PointerStatus.OnEnter);

        private void OnPointerExit(PointerEventData pointerEventData) => 
            _selectableButtonAnimation.StartAnimation(PointerStatus.OnExit);

        private void OnPointerDown(PointerEventData pointerEventData) =>
            _selectableButtonAnimation.StartAnimation(PointerStatus.OnDown);

        private void OnPointerUp(PointerEventData pointerEventData) =>
            _selectableButtonAnimation.StartAnimation(PointerStatus.OnUp);

        private void SubscribeToEvents()
        {
            _disposableService.OnDisposable += Dispose;
            _baseButton.Events.PointerEntered += OnPointerEnter;
            _baseButton.Events.PointerExited += OnPointerExit;
            _baseButton.Events.PointerDowned += OnPointerDown;
            _baseButton.Events.PointerUpped += OnPointerUp;
        }

        private void UnSubscribeToEvents()
        {
            _disposableService.OnDisposable -= Dispose;
            _baseButton.Events.PointerEntered -= OnPointerEnter;
            _baseButton.Events.PointerExited -= OnPointerExit;
            _baseButton.Events.PointerDowned -= OnPointerDown;
            _baseButton.Events.PointerUpped -= OnPointerUp;
        }
        
        public void Dispose()
        {
            _baseButton?.Dispose();
            UnSubscribeToEvents();
        }
    }
}