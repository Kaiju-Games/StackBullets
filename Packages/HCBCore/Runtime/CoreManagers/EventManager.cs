using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using HCB.Utilities;

namespace HCB.Core
{
    public static class EventManager
    {
        public static UnityEvent OnPlayerDataChange = new UnityEvent();
        public static CurrencyEvent OnCurrencyInteracted = new CurrencyEvent();

        public static UnityEvent OnBulletTake = new UnityEvent();

        public static UnityEvent OnBulletTakeExit = new UnityEvent();
        public static UnityEvent BulletIncrease = new UnityEvent();
        public static UnityEvent BulletDecrease = new UnityEvent();

        public static UnityEvent OnHit = new UnityEvent();



        #region Editor
        public static UnityEvent OnLevelDataChange = new UnityEvent();
        #endregion
    }

    public class PlayerDataEvent : UnityEvent<PlayerData> { }
    public class CurrencyEvent : UnityEvent<ExchangeType, int> { }
}