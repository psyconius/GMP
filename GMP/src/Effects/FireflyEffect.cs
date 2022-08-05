using SideLoader;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

namespace GMP
{
    public class StatusEffectExt
    {
        private bool timerSuspended = false;

        public bool TimerSuspended
        {
            get => timerSuspended;
            set => timerSuspended = value;
        }
    }

    public static class StatusEffectExtensions
    {

        private static ConditionalWeakTable<StatusEffect, StatusEffectExt> SuspendedEffects = new ConditionalWeakTable<StatusEffect, StatusEffectExt>();

        public static void SetTimerSuspended(this StatusEffect statusEffect, bool suspended)
        {
            StatusEffectExt ext = SuspendedEffects.GetValue(statusEffect, key => new StatusEffectExt());
            ext.TimerSuspended = suspended;
        }

        public static bool IsTimerSuspended(this StatusEffect statusEffect)
        {
            if (SuspendedEffects.TryGetValue(statusEffect, out StatusEffectExt ext))
            {
                return ext.TimerSuspended;
            }
            return false;
        }
    }

    public class FireFlyEffectTemplate : SL_Effect, ICustomModel
    {
        public Type SLTemplateModel => typeof(FireFlyEffectTemplate);
        public Type GameModel => typeof(FireFlyEffect);

        public override void ApplyToComponent<T>(T component) { }
        public override void SerializeEffect<T>(T effect) { }
    }

    public class FireFlyEffect : Effect, ICustomModel
    {

        public Type SLTemplateModel => typeof(FireFlyEffectTemplate);
        public Type GameModel => typeof(FireFlyEffect);

        private bool isActivated = false;

        private void ResetStatus(Character character)
        {
            isActivated = false;
            foreach (Light light in character.gameObject.GetComponents<Light>())
            {
                if (light.name == "firefly")
                {
                    Destroy(character.GetComponent<Light>());
                }
            }
        }

        public override void ActivateLocally(Character _affectedCharacter, object[] _infos)
        {
            // Check to see 
            if (!isActivated)
            {
                Light light = _affectedCharacter.gameObject.AddComponent<Light>();
                light.type = LightType.Point;
                light.name = "firefly";
                light.intensity = 1.75f;
                light.range = 30;
                light.color = Color.yellow;
                isActivated = true;
            }
        }

        public override void StopAffectLocally(Character _affectedCharacter)
        {
            m_parentStatusEffect.SetTimerSuspended(false);
            ResetStatus(_affectedCharacter);
        }
    }
}


