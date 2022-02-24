using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsSplitter
{

    public class SplitTestsJsonBuilder
    {
        private List<TestsOnPodModel> _models { get; set; }
        StringBuilder builder = new StringBuilder();

        public SplitTestsJsonBuilder(List<TestsOnPodModel> testsOnPodModels)
        {
            _models = testsOnPodModels;
        }

        public string BuildJson()
        {
            BuildMSTestArguments();

            return builder.ToString();
        }

        public string BuildMSTestArguments()
        {
            WithSplit();
            WithoutSplit();

            return builder.ToString();
        }

        private void WithSplit()
        {
            foreach (var model in _models.Where(m => !m.IsOne))
            {
                var testsArray = model.SplitTests.Split(',')
                    .Select(test => "/test:" + test);

                builder.Append("{name: \"/testContainer:").Append(model.TestDllName)
                    .Append(".dll").Append("\", tests: \"")
                    .Append(string.Join(@" ", testsArray))
                    .Append("\"}").Append(",").AppendLine();                
            }
        }

        private void WithoutSplit()
        {
            builder.Append("{name: \"");

            foreach (var model in _models.Where(m => m.IsOne))
            {
                builder.Append("/testContainer:").Append(model.TestDllName)
                    .Append(".dll");
            }

            builder.Append("\"}");
        }
    }
    
}
