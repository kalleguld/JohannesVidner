using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    public partial class Publication
    {
        public bool IsDescendant(Publication possibleParent)
        {
            var item = this;
            while (item.ParentPublicationId != item.Id && item.ParentPublicationId.HasValue)
            {
                if (item.ParentPublicationId == possibleParent.Id)
                {
                    return true;
                }
                item = item.ParentPublication;

            }
            return false;
        }
    }
}
