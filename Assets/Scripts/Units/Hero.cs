
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Mend
{
    public class Hero : Character
    {

        public static Hero current { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            current = this;
        }


    }

}