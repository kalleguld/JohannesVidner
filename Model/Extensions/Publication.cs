using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class PublicationExtensions
    {
        public static bool IsDesendent(this Publication child, Publication possibleParent)
        {
            var item = child;
            while (item.ParentPublicationId != item.Id && item.ParentPublicationId.HasValue)
            {
                if (item.ParentPublicationId == possibleParent.Id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
