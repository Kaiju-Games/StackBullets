﻿using UnityEngine.Events;
using MoreMountains.NiceVibrations;


namespace HCB.Core
{
    public static class HapticManager
    {
        public static UnityEvent OnHaptic = new UnityEvent();

        public static void Haptic(HapticTypes hapticType)
        {
            MMVibrationManager.Haptic(hapticType);
            OnHaptic.Invoke();
        }
    }
}
