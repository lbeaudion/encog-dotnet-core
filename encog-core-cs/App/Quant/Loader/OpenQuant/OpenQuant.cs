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
using System.Collections;
using System.IO;

namespace Encog.App.Quant.Loader.OpenQuant
{
    internal class OpenQuant
    {
        protected DateTime EndTime { get; set; } //end time for this bar.


        [Serializable]
        public class BarSize
        {
            // Fields
            public const long Day = 0x15180L;
            public const long Hour = 0xe10L;
            public const long Minute = 60L;
            public const long Month = 0x278d00L;
            public const long Second = 1L;
            public const long Week = 0x93a80L;
            public const long Year = 0x1e13380L;
        }

        public interface IDataSeries : IEnumerable
        {
            // Methods
            int Count { get; }
            string Description { get; set; }
            DateTime FirstDateTime { get; }
            object this[int index] { get; }
            object this[DateTime datetime] { get; set; }
            DateTime LastDateTime { get; }
            string Name { get; }
            void Add(DateTime datetime, object obj);
            void Clear();
            bool Contains(DateTime datetime);
            DateTime DateTimeAt(int index);
            void Flush();
            int IndexOf(DateTime datetime);
            int IndexOf(DateTime datetime, SearchOption option);
            void Remove(DateTime datetime);
            void RemoveAt(int index);
            void Update(DateTime datetime, object obj);
            void Update(int index, object obj);

            // Properties
        }

        #region collect

        #endregion
    }
}