using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Spikes : Projectile
    {
        [SerializeField] public int DamageValue;
        [SerializeField]public bool Fire = false;
        protected override void Impact(Collision otherCollision)
        {
            if(otherCollision.gameObject.tag != "Boss")
            {
                IDamagable damag = otherCollision.gameObject.GetComponent<IDamagable>();

                if (damag != null)
                {
                    damag.Damage(DamageValue);

                }
                if (otherCollision.gameObject.tag != "wall")
                {
                    ImpactFeedback();
                }


                Destroy(this.gameObject);
            }
            
        }

        protected override void Move()
        {
            if(Fire == true)
            {
                Vector3 moveOffset = Vector3.left * TravelSpeed;
                RB.MovePosition(RB.position + moveOffset);

            }
            
        }
        

        
    }
}
