using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace DataLoader
{
    using GLM.Entities;
    using WAD;
    using XML;

    public class AssetManager
    {
        private static readonly List<String> HandledExtensions = new List<String>(new[] { "fam" }); // new[] { "fam", "xml", "txt", "ndw", "cat" }

        private static readonly Lazy<AssetManager> LazyInstance = new Lazy<AssetManager>(() => new AssetManager(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static AssetManager Instance { get { return LazyInstance.Value; }}

        public static Dictionary<String, UInt32> ExtensionCounts = new Dictionary<String, UInt32>();

        private readonly Dictionary<String, FileEntry> _fileEntries = new Dictionary<String, FileEntry>();
        private readonly Dictionary<String, FileEntry> _duplicatedFileEntries = new Dictionary<String, FileEntry>();

        public Dictionary<String, FileEntry> FileEntries { get { return _fileEntries; } }
        public Dictionary<String, FileEntry> DuplicatedFileEntries { get { return _duplicatedFileEntries; } }
        public ContentHolder ContentHolder = new ContentHolder();
        public DataHolder DataHolder = new DataHolder();

        public void ReadEntries(String path, Boolean clear = false)
        {
            if (clear)
            {
                _fileEntries.Clear();
                _duplicatedFileEntries.Clear();
            }

            if (!Directory.Exists(path))
                throw new NullReferenceException("Path is invalid!");

            Directory.GetFiles(path, "*.glm", SearchOption.AllDirectories).ToList().ForEach(ReadFile);

            ReadHandledFiles();
        }

        private void ReadFile(String fileName)
        {
            using (var br = new BinaryReader(new FileStream(fileName, FileMode.Open)))
            {
                br.BaseStream.Seek(br.BaseStream.Length - 4, SeekOrigin.Begin);

                var headerOff = br.ReadInt32();
                br.BaseStream.Seek(headerOff, SeekOrigin.Begin);

                var strHeader = Encoding.UTF8.GetString(br.ReadBytes(4));
                Debug.Assert(strHeader == "CHNK");

                var opts = br.ReadBytes(4);
                Debug.Assert(opts[0] == 66); // No support for text reading yet!
                Debug.Assert(opts[1] == 76); // As in client

                var strTableOff = br.ReadInt32();
                var strTableSize = br.ReadInt32();
                var entryCount = br.ReadInt32();

                var currPos = br.BaseStream.Position;

                br.BaseStream.Seek(strTableOff, SeekOrigin.Begin);

                var stringTable = br.ReadBytes(strTableSize);
                var fileEntries = CreateEntriesByStringTable(stringTable);

                Debug.Assert(fileEntries.Count == entryCount);

                br.BaseStream.Position = currPos;

                foreach (var entry in fileEntries)
                {
                    entry.Read(br, fileName);
                    if (!_fileEntries.ContainsKey(entry.Name))
                        _fileEntries.Add(entry.Name, entry);
                    else
                        _duplicatedFileEntries.Add(entry.Name, entry);
                }
            }
        }

        private static List<FileEntry> CreateEntriesByStringTable(IEnumerable<Byte> data)
        {
            var sList = new List<FileEntry>();

            var sb = new StringBuilder();

            foreach (var t in data)
            {
                if (t != 0)
                    sb.Append((Char)t);
                else
                {
                    sList.Add(new FileEntry { Name = sb.ToString() });
                    sb.Clear();
                }
            }
            return sList;
        }

        public void ReadHandledFiles()
        {
            foreach (var fEntry in _fileEntries)
                ReadFileEntry(fEntry.Value);

            foreach (var fEntry in _duplicatedFileEntries)
                ReadFileEntry(fEntry.Value);
        }

        public void ReadFileEntry(FileEntry entry)
        {
            if (entry.IsRead)
                return;

            var ext = Path.GetExtension(entry.Name);
            if (String.IsNullOrWhiteSpace(ext))
                return;

            ext = ext.Replace(".", "").ToLower();

            if (ExtensionCounts.ContainsKey(ext))
                ++ExtensionCounts[ext];
            else
                ExtensionCounts.Add(ext, 1);

            if (!HandledExtensions.Contains(ext))
                return;

            entry.IsRead = true;

            using (var br = new BinaryReader(new FileStream(entry.FileName, FileMode.Open, FileAccess.Read)))
            {
                br.BaseStream.Position = entry.Offset;

                var stream = new MemoryStream(br.ReadBytes((Int32) entry.Size));
                using (var reader = new BinaryReader(stream))
                    ProcessReader(entry.Name, ext, reader);
            }
        }

        public FileEntry GetFileEntryByName(String name)
        {
            if (_fileEntries.ContainsKey(name))
                return _fileEntries[name];

            return _duplicatedFileEntries.ContainsKey(name) ? _duplicatedFileEntries[name] : null;
        }

        public BinaryReader GetBinaryReaderByName(String name)
        {
            var fEntry = GetFileEntryByName(name);
            if (fEntry == null)
                return null;

            using (var br = new BinaryReader(new FileStream(fEntry.FileName, FileMode.Open, FileAccess.Read)))
            {
                br.BaseStream.Position = fEntry.Offset;

                return new BinaryReader(new MemoryStream(br.ReadBytes((Int32)fEntry.Size)));
            }
        }

        public List<FileEntry> GetFileEntriesByName(String name)
        {
            var ret = (from e in _fileEntries where e.Key.StartsWith(name) select e.Value).ToList();
            ret.AddRange(from e in _duplicatedFileEntries where e.Key.StartsWith(name) select e.Value);
            return ret;
        }

        private static void ProcessReader(String name, String ext, BinaryReader br)
        {
            switch (ext)
            {
                case "fat": // Map written in text mode, actually it doesn't exist in the packed files
                    break;

                case "fam": // Map
                    SectorMap.Read(name, br);
                    break;

                case "xml": // Xml
                    using (var sw = new StreamWriter(name))
                        sw.WriteLine(Xml.Read(name, br).Content);
                    
                    break;

                case "txt": // Text
                    Txt.Read(name, br);
                    break;

                case "ndw":
                    NDW.Read(name, br);
                    break;

                // Not needed for the server (yet or anyways)
                case "cat": // Catalog
                case "dds":
                case "DDS":
                case "png": // Png
                case "tga": // Tga
                case "pgm":
                case "bak": // Backup
                case "anm": // Animation
                case "fx":
                case "fxh":
                case "fxi":
                case "geo":
                case "geo01":
                case "ogg": // Ogg
                    break;

                // Unknown yet
                case "tec":
                case "sha":
                case "spt":
                case "scc":
                case "cache":
                case "tk":
                case "lnk":
                    break;

                default:
                    Console.WriteLine(ext);
                    break;
            }
        }

        public void ReadWAD(String p)
        {
            var reader = new WADReader(p);
            ContentHolder = reader.ReadFile();

            Debugger.Break();
        }

        public void ReadXML(String p)
        {
            var des = new XmlSerializer(typeof(DataHolder));

            using (var sr = new StreamReader(p))
                DataHolder = des.Deserialize(sr) as DataHolder;
        }
    }

    public class FileEntry
    {
        public UInt32 Offset;
        public UInt32 Size;
        public UInt32 RealSize;
        public UInt32 ModifiedTime;
        public UInt16 Scheme;
        public UInt32 PackFile;
        public String Name;

        public Boolean IsRead { get; set; }
        public String FileName { get; set; }

        public void Read(BinaryReader br, String fName)
        {
            FileName = fName;

            Offset = br.ReadUInt32();
            Size = br.ReadUInt32();
            RealSize = br.ReadUInt32();
            ModifiedTime = br.ReadUInt32();
            Scheme = br.ReadUInt16();
            PackFile = br.ReadUInt32();
        }

        public override String ToString()
        {
            return String.Format("FileName: {0} | Name: {1}", FileName, Name);
        }
    }
}
