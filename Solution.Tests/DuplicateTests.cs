using Solution.Busienss.Services;
using Solution.Data.Interfaces;

namespace Solution.Tests
{
    [TestClass]
    public class DuplicateTests
    {
        [TestMethod]
        public void TestCanDetectDuplicateByName()
        {
            string path = Directory.GetCurrentDirectory();
            string directory = @"\..\..\..\Data\DuplicateByName";

            IDuplicateChecker checker = new DuplicateCheckerService();

            List<Data.DuplicateGroup> duplicateGroups = checker.GetDuplicateFilesFromPath(path + directory);

            var duplicateGroup = duplicateGroups.FirstOrDefault();

            Assert.IsNotNull(duplicateGroup);
            Assert.IsTrue(duplicateGroup.Duplicates.Count() == 2);
            Assert.IsTrue(duplicateGroup.DuplicateType == Data.Enums.DuplicateType.Name);
        }


        [TestMethod]
        public void TestCanDetectDuplicateByData()
        {
            string path = Directory.GetCurrentDirectory();
            string directory = @"\..\..\..\Data\DuplicateByData";

            IDuplicateChecker checker = new DuplicateCheckerService();

            IEnumerable<Data.DuplicateGroup> duplicateGroups = checker.GetDuplicateFilesFromPath(path + directory);

            var duplicateGroup = duplicateGroups.FirstOrDefault();

            Assert.IsNotNull(duplicateGroup);
            Assert.IsTrue(duplicateGroup.Duplicates.Count() == 2);
            Assert.IsTrue(duplicateGroup.DuplicateType == Data.Enums.DuplicateType.Data);

        }

    }
}