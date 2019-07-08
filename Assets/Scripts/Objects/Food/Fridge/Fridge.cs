using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Fridge : IFood
    {
        private void Start()
        {
            meals = 1;
            maxMeals = 10;
            NeedRefill needRefill = gameObject.AddComponent<NeedRefill>();
            needRefill.SetContainer(this);
        }

        public override bool AnswerAsk()
        {
            return meals != 0;
        }

        public override bool canBeUsed()
        {
            return meals != 0;
        }

        public override void onUse()
        {
            --meals;
        }
    }
}
