using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discrete4
{
    class Grandi
    {
        public IDictionary<int, int> execute(bool[][] adjacencyMatrix)
        {
            int verticesCount = adjacencyMatrix.Count();
            IDictionary<int, int> grandiFunctions = new Dictionary<int, int>();

            for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
            {
                if (!isExistsTransitionsFrom(vertexIndex, adjacencyMatrix))
                {
                    grandiFunctions.Add(vertexIndex, 0);
                }
            }

            while (grandiFunctions.Count < verticesCount)
            {
                for (int vertexIndex = 0; vertexIndex < verticesCount; vertexIndex++)
                {
                    if (!grandiFunctions.ContainsKey(vertexIndex) && isAllGrandiFunctionsKnown(vertexIndex, grandiFunctions, adjacencyMatrix))
                    {
                        int grandiFunctionValue = 0;
                        IList<int> grandiValuesForTransitions = new List<int>();
                        
                        for (int transitionVertixIndex = 0; transitionVertixIndex < verticesCount; transitionVertixIndex++)
                        {
                            if (adjacencyMatrix[vertexIndex][transitionVertixIndex])
                            {
                                if (grandiFunctions.TryGetValue(transitionVertixIndex, out grandiFunctionValue))
                                {
                                    grandiValuesForTransitions.Add(grandiFunctionValue);
                                }
                            }
                        }

                        grandiFunctionValue = findFirstNonnegativeExcept(grandiValuesForTransitions);

                        grandiFunctions[vertexIndex] = grandiFunctionValue;
                    }
                }
            }

            return grandiFunctions;
        }

        private bool isExistsTransitionsFrom(int vertexIndex, bool[][] adjacencyMatrix)
        {
            foreach (bool transitionExists in adjacencyMatrix[vertexIndex])
            {
                if (transitionExists)
                    return true;
            }

            return false;
        }


        private bool isAllGrandiFunctionsKnown(int vertexIndex, IDictionary<int, int> grandiFunctions, bool[][] adjacencyMatrix)
        {
            for (int i = 0; i < adjacencyMatrix.Count(); i++)
            {
                if (adjacencyMatrix[vertexIndex][i] && !grandiFunctions.ContainsKey(i))
                {
                    return false;
                }
            }

            return true;
        }

        private int findFirstNonnegativeExcept(IList<int> values)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (!values.Contains(i))
                {
                    return i;
                }
            }

            throw new Exception("Illegal state");
        }

    }
}
