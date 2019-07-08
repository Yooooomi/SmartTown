using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class Company : IObject
    {
        private int daysWorked;

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
            ++daysWorked;
        }
    }
}
