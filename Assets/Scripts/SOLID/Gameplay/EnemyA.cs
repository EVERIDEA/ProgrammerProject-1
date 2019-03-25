using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public class EnemyA : Enemy
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Something");
        }
    }
}