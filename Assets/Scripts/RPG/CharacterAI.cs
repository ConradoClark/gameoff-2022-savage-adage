using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RPG
{
    public abstract class CharacterAI : MonoBehaviour
    {
        public List<CharacterAction> Actions;
        public abstract CharacterAction GetNextAction();
        public abstract CharacterAction[] PeekNextActions(int amount);
    }
}
