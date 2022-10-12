using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Bullet : Projectile
    {
        [SerializeField] public int _damage = 1;

        protected override void Impact(Collision otherCollision)
        {


            IDamagable damag = otherCollision.gameObject.GetComponent<IDamagable>();

            if (damag != null)
            {
                damag.Damage(_damage);

            }
            if (otherCollision.gameObject.tag != "wall")
            {
                ImpactFeedback();
            }


            Destroy(this.gameObject);
        }
    }
}     
            




