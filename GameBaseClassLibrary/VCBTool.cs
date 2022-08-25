using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameBaseClassLibrary
{
    public class VCBTool
    {
        public static List<GameBases> ReadBasesFromVCB(string VCBpath)
        {
            List<GameBases> lRet = new List<GameBases>();

            FileInfo fn = new FileInfo(VCBpath);
            if (fn.Extension.Contains("vcb"))
            {
                using FileStream inputConfigStream = new FileStream(VCBpath, FileMode.Open, FileAccess.Read);
                using GZipStream decompressedConfigStream = new GZipStream(inputConfigStream, CompressionMode.Decompress);
                IFormatter formatter = new BinaryFormatter();
                lRet = (List<GameBases>)formatter.Deserialize(decompressedConfigStream);
            }

            return lRet;
        }
        public static void ExportFile(List<GameBases> precomp, GameConsoles console, string outf)
        {
            CheckAndFixFolder(outf);
            using Stream createConfigStream = new FileStream($@"{outf}\bases.vcb{console.ToString().ToLower()}", FileMode.Create, FileAccess.Write);
            using GZipStream compressedStream = new GZipStream(createConfigStream, CompressionMode.Compress);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(compressedStream, precomp);
        }
        private static void CheckAndFixFolder(string folder)
        {
            Directory.CreateDirectory(folder);
        }

        
    }
}
