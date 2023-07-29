﻿using System;
using System.Collections.Generic;
using Infrastructure.CodeBase.General.StateMachine.Interfaces;
using UnityEngine;

namespace Infrastructure.CodeBase.General.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();

        private IExitableState _activeState;

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();

            if (_states[typeof(TState)] is TState state)
            {
                _activeState = state;
                
                state.Enter();
            }
            
            else
                Debug.LogError($"{typeof(TState)}, Not Found");
        }

        public void Enter<TState, TArgs>(TArgs args) where TState : class, IStateWithArgument
        {
            _activeState?.Exit();

            if (_states[typeof(TState)] is TState state) 
                state.Enter(args);
            else
                Debug.LogError($"{typeof(TState)}, Not Found");
        }

        public void AddState<TState>(TState state) where TState : IExitableState
        {
            _states.Add(typeof(TState), state);
        }
    }
}