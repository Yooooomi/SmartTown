using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public abstract class IFood : IObject
    {
        [SerializeField]
        public int meals { get; protected set; }
        [SerializeField]
        public int maxMeals { get; protected set; }
        public void Refill()
        {
            meals = maxMeals;
        }
    }
}
