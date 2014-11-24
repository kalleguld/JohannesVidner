using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PublicationDepth
    {
        private readonly int depth;
        private readonly Publication publication;

        public PublicationDepth(Publication publication, int depth)
        {
            this.publication = publication;
            this.depth = depth;
        }

        public int Depth { get { return depth; } }
        public Publication Publication { get { return publication; } }
    }
}
