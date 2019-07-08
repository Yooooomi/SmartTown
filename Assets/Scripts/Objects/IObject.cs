using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public abstract class IObject : MonoBehaviour
    {
        private Entity owner;
        public List<INeed> objectNeeds;

        public void SetOwner(Entity ent)
        {
            if (owner != null)
            {
                owner.UnregisterObject(this);
            }
            owner = ent;
            owner.RegisterNewObject(this);
        }

        protected void Awake()
        {
            objectNeeds = new List<INeed>(GetComponents<INeed>());
        }

        // If this object can answer a need then it answers true
        public abstract bool AnswerAsk();

        // If this object can be used it answers true
        public abstract bool canBeUsed();

        // Called when this object is used
        public abstract void onUse();
    }
}
