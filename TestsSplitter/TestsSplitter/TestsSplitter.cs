using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TestsSplitter
{
    public class TestsSplitter
    {
        private Dictionary<string, string> _assembliesToSplit;
        private string _testsPath;
        private string _filter;
        public List<TestsOnPodModel> Models { get; set; }
        public TestsSplitter(string buildPath, string folderName, 
            string filter, Dictionary<string, string> testClassesSplitter)
        {
            Models = new List<TestsOnPodModel>();
            _testsPath = buildPath + @"\" + folderName;
            _filter = filter;
            _assembliesToSplit = testClassesSplitter;
        }

        public void SplitTests()
        {
            foreach (var testDll in Directory.GetFiles(_testsPath, _filter))
            {
                var assenmblyLoader = new TestAssemblyLoader(testDll);
                var testsClasses = assenmblyLoader
                .GetTestsClasses()
                .OrderBy(x => x.Name)
                .ToList();

                var testDllName = Path.GetFileNameWithoutExtension(testDll);
                var NeedSplit = _assembliesToSplit
                    .Any(key =>key.Key.Contains(testDllName));

                if (NeedSplit)
                {
                    SplitToGroupOfTestsClasses(testDllName, testsClasses);
                }
                else
                {
                    AddModel(testDllName, new List<string>(), isOne: true);
                }    
            }
        }

        private void SplitToGroupOfTestsClasses(string testDll, List<Type> testsClasses)
        {
            foreach (var assembllyToSplit in _assembliesToSplit)
            {
                var specificTestsClassesInAssembly = testsClasses
                    .Where(x => x.FullName.Contains(assembllyToSplit.Key))
                    .OrderBy(x => x.Name)
                    .ToList();

                if (specificTestsClassesInAssembly.Count == 0) continue;

                var testsGroup = specificTestsClassesInAssembly
                    .OrderBy(c => c.AssemblyQualifiedName)
                    .Select(x => x.FullName)
                    .ToList()
                    .ChunkBy(int.Parse(assembllyToSplit.Value));

                foreach (var tests in testsGroup)
                {
                    AddModel(testDll, tests);
                }

                testsClasses.RemoveAll(x => x.FullName.Contains(assembllyToSplit.Key));
            }
        }

        private void AddModel(string testDll, List<string> tests, bool isOne = false)
        {
            Models.Add(new TestsOnPodModel()
            {
                IsOne = isOne,
                SplitTests = string.Join(",", tests),
                TestDllName = testDll
            });
        }
    }

    public static class ListExtension
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            if (chunkSize == 0) chunkSize++;

            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
