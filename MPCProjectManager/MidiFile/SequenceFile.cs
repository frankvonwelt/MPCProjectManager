using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MPCProjectManager.MidiFile
{
    public class SequenceFile
    {
        public List<MidiChunk> MidiChunkList { get; set; }

        public int MidiFileFormat { get; set; }
        public int TrackCount { get; set; }

        public SequenceFile()
        {
            MidiChunkList = new List<MidiChunk>();
        }

        public void ParseSxqFile(string path)
        {
            BinaryReader binReader = new BinaryReader(File.Open(path, FileMode.Open));

            //split chunks
            while (binReader.PeekChar() != -1)
            {
                var header = binReader.ReadBytes(4);
                var length = binReader.ReadBytes(4);
                MidiChunk mc = new MidiChunk();
                mc.Header = header;
                mc.HeaderReadable = Encoding.Default.GetString(header);

                Array.Reverse(length);
                mc.ChunkLength = length;
                int intlength = BitConverter.ToInt32(length, 0);
                mc.ChunkLengthReadable = intlength;
                mc.Content = new byte[intlength];
                mc.Content = binReader.ReadBytes(intlength);
                mc.ContentReadable = Encoding.Default.GetString(mc.Content);

                this.MidiChunkList.Add(mc);
            }
            binReader.Close();
            binReader.Dispose();

            //read data from header chunk
            MidiFileFormat = Merge2BytesToInt(MidiChunkList[0].Content[0], MidiChunkList[0].Content[1]);

            TrackCount = Merge2BytesToInt(MidiChunkList[0].Content[2], MidiChunkList[0].Content[3]);

        }

        public int Merge2BytesToInt(byte b1, byte b2)
        {
            int result = b1;
            result = result << 8;
            result += b2;

            return result;
        }
    }
}
