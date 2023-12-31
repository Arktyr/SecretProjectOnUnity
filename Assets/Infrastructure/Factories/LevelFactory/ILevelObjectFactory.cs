﻿using Cysharp.Threading.Tasks;
using Zenject;

namespace Infrastructure.Creation
{
    public interface ILevelObjectFactory : IInitializable
    {
        public UniTask CreateAllObjects();
        
        public UniTask CreateAllUIObjects();

        public UniTask CreateCommonUI();

        public UniTask CreateLoadingScreen();
        public UniTask CreateCamera();
    }
}