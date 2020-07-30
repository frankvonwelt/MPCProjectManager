namespace MPCProjectManager.MidiFile
{
    public class MidiChunk
    {
        public byte[] Header { get; set; }
        public byte[] ChunkLength { get; set; }
        public byte[] Content { get; set; }
        public string HeaderReadable { get; set; }
        public int ChunkLengthReadable { get; set; }
        public string ContentReadable { get; set; }

        public MidiChunk()
        {
            Header = new byte[4];
            ChunkLength = new byte[4];
        }
    }
}
