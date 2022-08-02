using SideLoader;
using UnityEngine;
using System;
using SLExtensions;
using SideLoader_ExtendedEffects;
using System.Collections.Generic;

namespace GMP
{
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

        public override void ActivateLocally(Character _affectedCharacter, object[] _infos)
        {
            // Check to see 
            if (!isActivated)
            {
                Light light = _affectedCharacter.gameObject.AddComponent<Light>();
                light.type = LightType.Point;
                light.name = "firefly";
                light.intensity = 4;
                light.range = 35;
                light.color = Color.yellow;
                isActivated = true;
            }
        }

        public override void StopAffectLocally(Character _affectedCharacter)
        {
            isActivated = false;
            foreach (Light light in _affectedCharacter.gameObject.GetComponents<Light>())
            {
                if (light.name == "firefly")
                {
                    Destroy(_affectedCharacter.GetComponent<Light>());
                }
            }
        }
    }
}


