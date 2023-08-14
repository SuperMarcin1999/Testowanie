using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace MyProject.Tests.Data
{
    public class JsonTestData : DataAttribute
    {
        private readonly string _path;

        public JsonTestData(string path)
        {
            _path = path;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            if (testMethod == null)
                throw new ArgumentNullException(nameof(testMethod));

            var currentPath = Directory.GetCurrentDirectory();
            var fullPath = Path.GetRelativePath(currentPath, _path);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException();

            var jsonData = File.ReadAllText(fullPath);
            var data = JsonConvert.DeserializeObject<IEnumerable<object[]>>(jsonData);

            return data;
        }
    }
}
