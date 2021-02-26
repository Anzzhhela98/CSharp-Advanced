using System.Collections.Generic;

namespace _MilitaryElite.Models
{
    public interface ILieutenantGeneral : IPrivate
    {
        public IReadOnlyCollection<ISoldier> Privates { get; }
       public  void AddPrivate(ISoldier @private);
    }
}
