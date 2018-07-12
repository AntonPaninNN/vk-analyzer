using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkSearch.Strategy
{
    public abstract class ITreeSearchStrategy : ISearchStrategy
    {
        private string coreId;
        private int depth;
        private bool onFirstStep;
        private string nextIterationCriteria;

        public bool OnFirstStep { get { return onFirstStep; } set { onFirstStep = value; } }
        public string CoreId { get { return coreId; } set { coreId = value; } }
        public int Depth { get { return depth; } set { depth = value; } }
        public string NextIterationCriteria { get { return nextIterationCriteria; } 
            set { nextIterationCriteria = value; } }
    }
}
