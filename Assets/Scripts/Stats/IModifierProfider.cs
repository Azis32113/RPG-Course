using System.Collections.Generic;

namespace RPG.Stats
{
    public interface IModifierProfider
    {
        IEnumerable<float> GetAdditiveModifiers(Stat stat);
        IEnumerable<float> GetPercentageModifiers(Stat stat);
    }
}