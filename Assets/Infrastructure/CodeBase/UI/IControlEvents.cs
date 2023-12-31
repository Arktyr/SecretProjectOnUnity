﻿using System;
using UnityEngine.EventSystems;

namespace Infrastructure.CodeBase.UI
{
    public interface IControlEvents
    {
        public event Action<PointerEventData> PointerEntered;
        public event Action<PointerEventData> PointerExited;
        public event Action<PointerEventData> PointerDowned;
        public event Action<PointerEventData> PointerUpped;
        public event Action<PointerEventData> PointerClicked;
    }
}