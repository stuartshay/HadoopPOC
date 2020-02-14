using CsvHelper;
using Microsoft.Hadoop.MapReduce;
using System.IO;

namespace Sixeyed.HadoopDotNet.Sdk
{
    public class AreaClassificationMapper : MapperBase
    {
        private static int CLASSIFICATION_FIELD_INDEX = 29;

        public override void Map(string line, MapperContext context)
        {
            using (var reader = new StringReader(line))
            using (var parser = new CsvParser(reader))
            {
                var fields = parser.Read();
                if (fields.Length >= CLASSIFICATION_FIELD_INDEX)
                {
                    var classification = fields[CLASSIFICATION_FIELD_INDEX];
                    context.Log($"MAPPER - key: {classification}");
                    context.EmitKeyValue(classification, "1");
                }
            }
            
        }
    }
}
