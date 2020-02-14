using Microsoft.Hadoop.MapReduce;
using System.Collections.Generic;
using System.Linq;

namespace Sixeyed.HadoopDotNet.Sdk
{
    public class AreaClassificationReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            var total = values.Sum(x => long.Parse(x));
            context.Log($"REDUCER - key: {key}, total: {total}");
            context.EmitKeyValue(key, total.ToString());
        }
    }
}
