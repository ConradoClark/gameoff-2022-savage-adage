using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.RPG.AI
{
    public class RepeatedActionAI : CharacterAI
    {
        public override CharacterAction GetNextAction()
        {
            return Actions.FirstOrDefault();
        }

        public override CharacterAction[] PeekNextActions(int amount)
        {
            return Enumerable.Repeat(Actions.FirstOrDefault(), amount).ToArray();
        }
    }
}
