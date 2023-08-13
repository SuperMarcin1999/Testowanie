using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyProject.Tests.Data
{
    public class MetricBmiCalculatorTestData : IEnumerable<object[]>
    {
        private const string JSON_PATH = "Data/MetricBmiCalculatorTestData.json";
        public IEnumerator<object[]> GetEnumerator()
        {
            var currentPath = Directory.GetCurrentDirectory();
            var fullPath = Path.GetRelativePath(currentPath, JSON_PATH);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException();

            var jsonData = File.ReadAllText(fullPath);
            var data = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);

            return data!.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
