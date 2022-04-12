using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public class PrefixBrandName : ValueObject
    {
        const string BRANDNNAMESTARTWITH = "BRD_";
        public string Name { get; private set; }
        
        public static PrefixBrandName SetName(string name)
        {
            var _brandNomenclatureName = new PrefixBrandName { Name = name };

            if(!name.StartsWith(BRANDNNAMESTARTWITH))
            {
                throw new ArgumentException($"Unsupported name. Name must be start by {BRANDNNAMESTARTWITH}");
            }

            return _brandNomenclatureName;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
