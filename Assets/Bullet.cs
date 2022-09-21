using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Bullet : Projectile
    {
        private const int _damage = 1;

        protected override void Impact(Collision otherCollision)
        {
            IDamagable damag = otherCollision.gameObject.GetComponent<IDamagable>();

            if(damag != null)
            {
                damag.Damage(_damage);

            }

            ImpactFeedback();

            Destroy(this.gameObject);
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
