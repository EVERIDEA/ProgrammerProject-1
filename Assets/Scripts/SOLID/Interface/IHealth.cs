﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Everidea.Core
{
    public interface IHealth
    {
        void SetHealth(float damage);
        Health GetHealth();
    }
}
