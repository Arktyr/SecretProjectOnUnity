using System;
using System.Collections.Generic;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine.States;
using UnityEngine;

namespace Infrastructure.Gameplay.Persons.PlayerControlled.StateMachine
{
    public class PlayerStateMachine : IPlayerStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();
        
        public PlayerStateType CurrentState { get; private set; }
        
        private IExitableState _activeState;
        
        public void Enter<TState>() where TState : class, IPlayerState
        {
            if (_states[typeof(TState)] is TState state)
            {
                _activeState?.Exit();
                
                SetActiveState(state);
                SetCurrentState(state);
                
                state.Enter();
            }
            else
                Debug.LogError($"{typeof(TState)}, Not Found");
        }
        
        public void AddState<TState>(TState state) where TState : IExitableState => _states.Add(typeof(TState), state);

        private void SetCurrentState<TState>(TState state) where TState : IExitableState
        {
            switch (state)
            {
                case IdlingState: CurrentState = PlayerStateType.IdlingState;
                    break;
                case RunState: CurrentState = PlayerStateType.RunState;
                    break;
                default:
                    Debug.LogError($"{state}, Current state no found)");
                    break;
            }
        }

        private void SetActiveState<TState>(TState state) where TState : IExitableState => _activeState = state;
    }
}