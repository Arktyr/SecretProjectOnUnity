using System;
using Infrastructure.CodeBase.Services.UnSubscribe;
using Infrastructure.Gameplay.Persons.Common.Injuring;
using TMPro;
using UnityEngine.UI;

namespace Infrastructure.Gameplay.UI.Bars
{
    public class HealthBar : IHealthBar, IDisposable
    {
        private IHealth _health;
        private float _maxHealth;
        
        private Image[] _fillerPart;
        private TMP_Text _text;

        private readonly IDisposableService _disposableService;

        public HealthBar(IDisposableService disposableService)
        {
            _disposableService = disposableService;
        }

        public void Construct(IHealth health,
            Image[] image,
            TMP_Text text,
            float maxHealth)
        {
            _health = health;
            _fillerPart = image;
            _text = text;
            _maxHealth = maxHealth;

            SubscribeToEvents();
            
            ChangeHealthBarFill(health.Healths.Value);
        }

        private void SubscribeToEvents()
        {
            _disposableService.OnDisposable += Dispose;
            _health.Healths.Changed += ChangeHealthBarFill;
            _health.Died += Dispose;
        }

        private void UnSubscribeToEvents()
        {
            _health.Healths.Changed -= ChangeHealthBarFill;
            _disposableService.OnDisposable -= Dispose;
            _health.Died -= Dispose;
        }

        private void ChangeHealthBarFill(float health)
        {
            float fill = health/_maxHealth;

            foreach (var fillerPart in _fillerPart) fillerPart.fillAmount = fill;

            _text.SetText($"{health}");
        }

        public void Dispose() => UnSubscribeToEvents();
    }
}