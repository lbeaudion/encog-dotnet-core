//
// Encog(tm) Core v3.2 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2013 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Encog.Neural.NEAT.Training.Opp.Links;
using Encog.MathUtil.Randomize;
using Encog.ML.EA.Genome;

namespace Encog.Neural.NEAT.Training.Opp
{
    /// <summary>
    /// Mutate the weights of a genome. A method is select the links for mutation.
    /// Another method should also be provided for the actual mutation.
    /// 
    /// -----------------------------------------------------------------------------
    /// http://www.cs.ucf.edu/~kstanley/ Encog's NEAT implementation was drawn from
    /// the following three Journal Articles. For more complete BibTeX sources, see
    /// NEATNetwork.java.
    /// 
    /// Evolving Neural Networks Through Augmenting Topologies
    /// 
    /// Generating Large-Scale Neural Networks Through Discovering Geometric
    /// Regularities
    /// 
    /// Automatic feature selection in neuroevolution
    /// </summary>
    public class NEATMutateWeights : NEATMutation
    {
        /// <summary>
        /// The method used to select the links to mutate.
        /// </summary>
        private ISelectLinks linkSelection;

        /// <summary>
        /// The method used to mutate the selected links.
        /// </summary>
        private IMutateLinkWeight weightMutation;

        /// <summary>
        /// Construct a weight mutation operator.
        /// </summary>
        /// <param name="theLinkSelection">The method used to choose the links for mutation.</param>
        /// <param name="theWeightMutation">The method used to actually mutate the weights.</param>
        public NEATMutateWeights(ISelectLinks theLinkSelection,
                IMutateLinkWeight theWeightMutation)
        {
            this.linkSelection = theLinkSelection;
            this.weightMutation = theWeightMutation;
        }

        /// <summary>
        /// The method used to select links for mutation.
        /// </summary>
        public ISelectLinks LinkSelection
        {
            get
            {
                return this.linkSelection;
            }
        }

        /// <summary>
        /// The method used to mutate the weights.
        /// </summary>
        public IMutateLinkWeight WeightMutation
        {
            get
            {
                return this.weightMutation;
            }
        }

        /// <inheritdoc/>
        public override void PerformOperation(EncogRandom rnd, IGenome[] parents,
                int parentIndex, IGenome[] offspring,
                int offspringIndex)
        {
            NEATGenome target = ObtainGenome(parents, parentIndex, offspring,
                    offspringIndex);
            double weightRange = ((NEATPopulation)Owner.Population).WeightRange;
            IList<NEATLinkGene> list = this.linkSelection.SelectLinks(rnd,
                    target);
            foreach (NEATLinkGene gene in list)
            {
                this.weightMutation.MutateWeight(rnd, gene, weightRange);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("[");
            result.Append(this.GetType().Name);
            result.Append(":sel=");
            result.Append(this.linkSelection.ToString());
            result.Append(",mutate=");
            result.Append(this.weightMutation.ToString());
            result.Append("]");
            return result.ToString();
        }
    }
}