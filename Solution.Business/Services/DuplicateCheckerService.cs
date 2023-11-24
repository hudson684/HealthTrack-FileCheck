using Solution.Data;
using Solution.Data.Interfaces;
using Solution.Data.Extensions;
using Solution.Data.Enums;
using Solution.Business.Services;

namespace Solution.Busienss.Services
{
    public class DuplicateCheckerService : IDuplicateChecker
    {

        private Dictionary<byte[], List<FileDetails>> fileNameDuplicates;
        private Dictionary<byte[], List<FileDetails>> dataDuplicates;

        private Dictionary<byte[], List<FileDetails>> fileDataBaseList;
        private Dictionary<byte[], List<FileDetails>> fileNameBaseList;

        private ProcessReaderWriter processReaderWriter;

        public DuplicateCheckerService()
        {
            fileNameDuplicates = new Dictionary<byte[], List<FileDetails>>(ByteArrayComparer.Default);
            dataDuplicates = new Dictionary<byte[], List<FileDetails>>(ByteArrayComparer.Default);

            fileDataBaseList = new Dictionary<byte[], List<FileDetails>>(ByteArrayComparer.Default);
            fileNameBaseList = new Dictionary<byte[], List<FileDetails>>(ByteArrayComparer.Default);
        }

        public List<DuplicateGroup> GetDuplicateFilesFromPath(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                var files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    var fileName = Path.GetFileName(file);
                    var filehash = fileName.ToHash();

                    var dataHash = File.ReadAllText(file).ToHash();
                    var fileDetails = new FileDetails()
                    {
                        Name = fileName,
                        FullPath = file,
                        FileHash = filehash,
                        DataHash = dataHash
                    };

                    // Check by file type
                    if (fileDataBaseList.ContainsKey(dataHash))
                    {
                        dataDuplicates = ProcessDuplicate(DuplicateType.Data, fileDetails);
                    }
                    else
                    {
                        var filelist = new List<FileDetails>
                        {
                            fileDetails
                        };
                        fileDataBaseList.Add(dataHash, filelist);
                    }

                    // Check by file name
                    if (fileNameBaseList.ContainsKey(filehash))
                    {
                        fileNameDuplicates = ProcessDuplicate(DuplicateType.Name, fileDetails);
                    }
                    else
                    {
                        var filelist = new List<FileDetails>
                        {
                            fileDetails
                        };
                        fileNameBaseList.Add(filehash, filelist);
                    }
                }
            }
            else
            {
                return null;
            }


            List<DuplicateGroup> duplicateReturn = BuildDuplicateGroups(DuplicateType.Data, dataDuplicates).ToList();
            List<DuplicateGroup> fileNameDuplicatesGroup = BuildDuplicateGroups(DuplicateType.Name, fileNameDuplicates).ToList();
            duplicateReturn.AddRange(fileNameDuplicatesGroup);

            return duplicateReturn.ToList();
        }

        /// <summary>
        /// Processes the file type and assigns to the correct internal dictionary based on duplicate type enum provided.
        /// </summary>
        /// <param name="duplicateType"></param>
        /// <param name="fileDetails"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private Dictionary<byte[], List<FileDetails>> ProcessDuplicate(DuplicateType duplicateType, FileDetails fileDetails)
        {

            Dictionary<byte[], List<FileDetails>> tempDupliucateDict;
            Dictionary<byte[], List<FileDetails>> tempBaseDict;
            byte[]? hash;
            switch (duplicateType)
            {
                case DuplicateType.Data:
                    tempDupliucateDict = dataDuplicates;
                    tempBaseDict = fileDataBaseList;
                    hash = fileDetails.DataHash;
                    break;
                case DuplicateType.Name:
                    tempDupliucateDict = fileNameDuplicates;
                    tempBaseDict = fileNameBaseList;
                    hash = fileDetails.FileHash;
                    break;
                default:
                    throw new NotImplementedException("Duplicate type provided was not expected");
            }

            if (hash is null)
                throw new NotImplementedException("Hash not provided in fileDetails");

            if (tempDupliucateDict.ContainsKey(hash))
            {
                tempDupliucateDict[hash].Add(fileDetails);
            }
            else
            {
                var filelist = tempBaseDict[hash];
                filelist.Add(fileDetails);
                tempDupliucateDict.Add(hash, filelist);
            }

            return tempDupliucateDict;
        }

        private IEnumerable<DuplicateGroup> BuildDuplicateGroups(DuplicateType duplicateType, Dictionary<byte[], List<FileDetails>> duplicateDict)
        {
            foreach(List<FileDetails> duplicates in duplicateDict.Values ) {
                yield return BuildGroup(duplicateType, duplicates);
            }
        }


        private DuplicateGroup BuildGroup(DuplicateType duplicateType, List<FileDetails> duplicates)
        {
            return new DuplicateGroup(duplicateType, duplicates.Select(d => d.FullPath).ToList());
        }
    }
}
