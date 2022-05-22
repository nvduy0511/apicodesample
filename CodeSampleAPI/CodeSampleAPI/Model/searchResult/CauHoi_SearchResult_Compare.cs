using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSampleAPI.Model.searchResult
{
    public class CauHoi_SearchResult_Compare : IEqualityComparer<CauHoi_SearchResult>
    {
        public bool Equals(CauHoi_SearchResult x, CauHoi_SearchResult y)
        {
            return x.id == y.id && x.moTa == y.moTa;
        }

        public int GetHashCode([DisallowNull] CauHoi_SearchResult obj)
        {
            if (Object.ReferenceEquals(obj, null)) return 0;

            int hashProductName = obj.moTa == null ? 0 : obj.moTa.GetHashCode();

            int hashProductCode = obj.id.GetHashCode();

            return hashProductName ^ hashProductCode;
        }
    }
}
