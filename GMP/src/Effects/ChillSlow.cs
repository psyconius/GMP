using SideLoader;
using UnityEngine;
using System;
using SLExtensions;
using SideLoader_ExtendedEffects;
using System.Collections.Generic;
using System.Collections;

namespace GMP
{
    public class ChillSlowTemplate : SL_Effect, ICustomModel
    {
        public Type SLTemplateModel => typeof(ChillSlowTemplate);
        public Type GameModel => typeof(ChillSlow);

        public override void ApplyToComponent<T>(T component) { }
        public override void SerializeEffect<T>(T effect) { }
    }

    public class ChillSlow : Effect, ICustomModel
    {

        public Type SLTemplateModel => typeof(ChillSlowTemplate);
        public Type GameModel => typeof(ChillSlow);

        private bool isActivated = false;

        public override void ActivateLocally(Character _affectedCharacter, object[] _infos)
        {
            if (!isActivated)
            {
                // Knocking down, lowering frost resistance, and adding slow down effect
                Plugin.Log.LogMessage("Effects for " + _affectedCharacter.Name);
                _affectedCharacter.StatusEffectMngr.AddStatusEffect("Chill");
                _affectedCharacter.StatusEffectMngr.AddStatusEffect("Crippled");
                isActivated = true;
            }

        }

        public override void StopAffectLocally(Character _affectedCharacter)
        {
            // Remove Effects / Deactivate
            _affectedCharacter.StatusEffectMngr.CleanseStatusEffect("Chill");
            _affectedCharacter.StatusEffectMngr.CleanseStatusEffect("Crippled");
            isActivated = false;
        }
    }
}