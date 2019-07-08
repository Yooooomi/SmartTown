using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Shop : IObject
    {
        [SerializeField]
        private int storage;

        public override bool AnswerAsk()
        {
            return true;
        }

        public override bool canBeUsed()
        {
            return true;
        }

        public override void onUse()
        {
            --storage;
        }
    }
}
