﻿/* The MIT License (MIT)
*
* Copyright (c) 2014 Pawel Drozdowski
* 
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
* 
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace TspLibNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph;
    using TspLibNet.Tours;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Graph.Edges;
    using TspLibNet.Graph.EdgeWeights;
    using TspLibNet.Graph.FixedEdges;
    using TspLibNet.Graph.Depots;
    using TspLibNet.Graph.Demand;

    /// <summary>
    /// Problem base class
    /// </summary>
    public abstract class ProblemBase : IProblem
    {
        public ProblemBase(string name, string comment, INodeProvider nodeProvider, IEdgeProvider edgeProvider, IEdgeWeightsProvider edgeWeightsProvider, IFixedEdgesProvider fixedEdgesProvider)
        {
            if (nodeProvider == null)
            {
                throw new ArgumentNullException("nodeProvider");
            }

            if (edgeProvider == null)
            {
                throw new ArgumentNullException("edgeProvider");
            }

            if (edgeWeightsProvider == null)
            {
                throw new ArgumentNullException("edgeWeightsProvider");
            }

            if (fixedEdgesProvider == null)
            {
                throw new ArgumentNullException("fixedEdgesProvider");
            }


            this.Name = name;
            this.Comment = comment;
            this.NodeProvider = nodeProvider;
            this.EdgeProvider = edgeProvider;
            this.EdgeWeightsProvider = edgeWeightsProvider;
            this.FixedEdgesProvider = fixedEdgesProvider;
        }

        /// <summary>
        /// Gets nodes provider
        /// </summary>
        public INodeProvider NodeProvider { get; protected set; }

        /// <summary>
        /// Gets Edges provider
        /// </summary>
        public IEdgeProvider EdgeProvider { get; protected set; }

        /// <summary>
        /// Gets Edge Weights Provider
        /// </summary>
        public IEdgeWeightsProvider EdgeWeightsProvider { get; protected set; }

        /// <summary>
        /// Gets Fixed Edges Provider
        /// </summary>
        public IFixedEdgesProvider FixedEdgesProvider { get; protected set; }

        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        public string Comment { get; protected set; }
        
        /// <summary>
        /// Gets tour distance for a given problem
        /// </summary>
        /// <param name="tour">Tour to check</param>
        /// <returns>Tour distance</returns>
        public abstract double TourDistance(ITour tour);
    }
}
