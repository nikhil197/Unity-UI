using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Character
    {
        [SerializeField]
        public string Name;

        [SerializeField]
        public Sprite[] Images;

        [SerializeField]
        public int UnlockLevel = 0;

        public bool IsSelected = false;
    }
}
