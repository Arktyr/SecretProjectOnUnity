using System;
using UnityEngine.EventSystems;

namespace Infrastructure.CodeBase.UI.Buttons
{
    public class BaseButton : IDisposable
    {
        public IControlEvents Events { get; private set; }
        private Action _action;

        public event Action Clicked;
        
        public void Construct(IControlEvents controlEvents, Action action)
        {
            Events = controlEvents;
            _action = action;
            
            SubscribeToEvents();
        }

        private void OnClick(PointerEventData eventData) => Clicked?.Invoke();

        private void SubscribeToEvents()
        {
            Clicked += _action;
            Events.PointerClicked += OnClick;
        }
        
        private void UnSubscribeToEvents()
        {
            Clicked -= _action;
            Events.PointerClicked -= OnClick;
        }
        
        public void Dispose() => UnSubscribeToEvents();
    }
}