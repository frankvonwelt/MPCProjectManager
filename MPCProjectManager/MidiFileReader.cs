/*
 * Created by: Leslie Sanford
 * 
 * Contact: jabberdabber@hotmail.com
 * 
 * Last modified: 05/07/2004
 */

using System;
using System.IO;

namespace Multimedia.Midi
{
	/// <summary>
	/// Reads data from Midi files and stores them in sequences.
	/// </summary>
	public class MidiFileReader
	{
        #region MidiFileReader Members

        #region Constants

        // The length in bytes used to store the length of a chunk.
        private const int LengthByteCount = 4;

        // Length in bytes of the Midi file header.
        private const int FileHeaderLength = 6;
        
        // Length in bytes of the format data.
        private const int FormatByteCount = 2;

        // The format maximum value.
        private const int FormatMax = 2;
        
        // Length in bytes of the track count.
        private const int TrackCountByteCount = 2;

        // Length in bytes of the division data.
        private const int DivisionByteCount = 2;

        // Bit flat used to determine if a byte is a status byte.
        private const int StatusFlag = 0x80;

        // Number of bits to shift bytes in parsing data.
        private const int Shift = 7;

        // Masks Midi channel.
        private const int ChannelMask = 240;        

        #endregion

        #region Read Only

        // File header ID.
        private static readonly byte[] FileHeaderID =
        {
            (byte)'M',
            (byte)'T',
            (byte)'h',
            (byte)'d',
            (byte) 0,
            (byte) 0,
            (byte) 0,
            (byte) 6
        };

        // Track header ID
        private static readonly byte[] TrackHeaderID =
        {
            (byte)'M',
            (byte)'T',
            (byte)'r',
            (byte)'k'
        };

        #endregion
        
        #region Fields

        // Format data.
        private short format;

        // The sequence to store the Midi data into.
        private Sequence sequence;

        // The tracks that make up the Midi file.
        private Track[] tracks;        

        // For reading the data from the Midi file.
        private BinaryReader binReader;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the MidiFileReader class with the 
        /// specified path of the Midi file to read.
        /// </summary>
        /// <param name="path">
        /// The path of the Midi file to read.
        /// </param>
        public MidiFileReader(string path)
        {
            // Open Midi file for reading.
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);            

            // Create binary reader for reading Midi data from file.
            binReader = new BinaryReader(fs);

            try
            {
                // Make sure this is a Midi file.
                ThrowOnError(VerifyFileType());

                // Read format data.
                ThrowOnError(ReadFormat());           

                // Read the number of tracks that are in the Midi file.
                ThrowOnError(ReadTrackCount());

                // Read division data.
                ReadDivision();

                // Read the Midi tracks.
                ReadTracks();
            }
            catch(EndOfStreamException)
            {
                ThrowOnError(MidiFileResult.EndofFileError);
            }
            finally
            {
                binReader.Close();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Verifies that the file is a Midi file.
        /// </summary>
        /// <returns>
        /// <b>MidiFileResult.Success</b> if the file is a Midi file; 
        /// otherwise, <b>MidiFileResult.NotMidiFile</b>.
        /// </returns>
        private MidiFileResult VerifyFileType()
        {
            MidiFileResult result = MidiFileResult.Success;

            // Matches file against Midi file header.
            for(int i = 0; i < FileHeaderID.Length && 
                result == MidiFileResult.Success; i++)
            {
                // If there is a mismatch.
                if(binReader.ReadByte() != FileHeaderID[i])
                {
                    // Indicate that this is not a Midi file.
                    result = MidiFileResult.NotMidiFile;
                }
            } 

            return result;
        }        

        /// <summary>
        /// Reads the format type.
        /// </summary>
        /// <returns>
        /// <b>MidiFileResult.Success</b> if the format was read and is valid;
        /// otherwise, <b>MidiFileResult.InvalidFormat</b>.
        /// </returns>
        private MidiFileResult ReadFormat()
        {
            MidiFileResult result = MidiFileResult.Success;
            byte[] f = binReader.ReadBytes(FormatByteCount);

            // Convert array to the same byte order as this platform.
            ConvertByteArray(f);

            // Convert array to number.
            format = BitConverter.ToInt16(f, 0);

            // If the format is an invalid value.
            if(format > FormatMax)
            {
                // Indicate that the format is invalid.
                result = MidiFileResult.InvalidFormat;
            }

            return result;
        }

        /// <summary>
        /// Reads the number of tracks in the Midi file.
        /// </summary>
        /// <returns>
        /// <b>MidiFileResult.Succes</b> if the track count and format type 
        /// are valid; otherwise, <b>MidiFileResult.InvalidFormat</b>.
        /// </returns>
        private MidiFileResult ReadTrackCount()
        {
            MidiFileResult result = MidiFileResult.Success;
            byte[] trackCount = binReader.ReadBytes(TrackCountByteCount);

            // Convert array to the same byte order as this platform.
            ConvertByteArray(trackCount);

            // Convert array to number.
            tracks = new Track[BitConverter.ToInt16(trackCount, 0)];            

            // If there are more than one track and the Midi file is type 0.
            if(tracks.Length > 1 && Format == 0)
            {
                // Indicate that the format is invalid. A type 0 Midi file can
                // only have one track.
                result = MidiFileResult.InvalidFormat;
            }

            // If the format is valid.
            if(result == MidiFileResult.Success)
            {
                // Allocate tracks.
                for(int i = 0; i < tracks.Length; i++)
                {
                    tracks[i] = new Track();
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the division value.
        /// </summary>
        private void ReadDivision()
        {
            byte[] d = binReader.ReadBytes(DivisionByteCount);

            // Convert array to the same byte order as this platform.
            ConvertByteArray(d);

            // Create sequence to hold tracks from the Midi file.
            sequence = new Sequence(BitConverter.ToInt16(d, 0));
        }

        /// <summary>
        /// Reads the track data from the Midi file.
        /// </summary>
        private void ReadTracks()
        {
            // Read each track from the Midi file.
            for(int i = 0; i < tracks.Length; i++)
            {
                FindNextTrack();
                ReadNextTrack(i);
                sequence.Add(tracks[i]);
            }
        }

        /// <summary>
        /// Finds the next track in the Midi file.
        /// </summary>
        private void FindNextTrack()
        {
            bool found = false;

            // While the next track has not been found.
            while(!found)
            {
                // Search for the beginning of the next track.
                while(binReader.ReadByte() != TrackHeaderID[0])
                {
                    continue;
                }

                bool match = true;

                // Check if the beginning of the next track has been found.
                for(int i = 1; i < TrackHeaderID.Length && match; i++)
                {
                    // If there is a mismatch between the track header and
                    // this point in the Midi file.
                    if(binReader.ReadByte() != TrackHeaderID[i])
                    {
                        // Indicate mismatch.
                        match = false;
                    } 
                }

                // If the track header and file match.
                if(match)
                {
                    // Indicate that the next track has been found.
                    found = true;
                }
            }
        }

        /// <summary>
        /// Reads the data for the next track from the Midi file.
        /// </summary>
        /// <param name="trackNum">
        /// The track number.
        /// </param>
        private void ReadNextTrack(int trackNum)
        {
            MetaType metaType = MetaType.TrackName;
            int status = 0;
            int runningStatus = 0;

            // Read length of track.
            binReader.ReadBytes(LengthByteCount);

            // Continue reading Midi events until the end of the track.
            while(metaType != MetaType.EndOfTrack)
            {
                // Next Midi message in track.
                IMidiMessage msg = null;

                // Ticks for next Midi event.
                int ticks = ReadVariableLengthQuantity();

                // Read status byte for the next Midi message.
                status = binReader.ReadByte(); 

                // If this is a status byte.
                if((status & StatusFlag) == StatusFlag)
                { 
                    // If the next Midi message is a channel message.
                    if(ChannelMessage.IsChannelMessage(status))
                    {
                        // Read channel message from the Midi file.
                        msg = ReadChannelMessage(status);  
                      
                        // Update running status.
                        runningStatus = status;                         
                    }
                    // Else if the next Midi message is a meta message.
                    else if(MetaMessage.IsMetaMessage(status))
                    {
                        // Read the type of meta message.
                        metaType = (MetaType)binReader.ReadByte();

                        // Read the length of the meta message data.
                        int length = ReadVariableLengthQuantity();

                        // Read the meta message data.
                        byte[] data = binReader.ReadBytes(length);

                        // Create meta message.
                        msg = new MetaMessage(metaType, data);
                    }
                    // Else if the next Midi message is a system exclusive 
                    // message.
                    else if(SysExMessage.IsSysExMessage(status))
                    {
                        // The type of system exclusive message.
                        SysExType type = (SysExType)status;

                        // Read the length of the system exclusive data.
                        int length = ReadVariableLengthQuantity();

                        // Read the system exclusive data.
                        byte[] data = binReader.ReadBytes(length);

                        // Create system exclusive message.
                        msg = new SysExMessage(type, data);
                    }
                }
                // Assumes running status.
                else
                {
                    // Create channel message.
                    msg = ReadChannelMessage(runningStatus, status);
                }

                // Create the next Midi event and store it in the specified
                // track.
                MidiEvent e = new MidiEvent(msg, ticks);
                tracks[trackNum].Add(e);
            } 
        }

        /// <summary>
        /// Converts byte order of the specified array to match the byte order
        /// of this platform.
        /// </summary>
        /// <param name="array">
        /// The array to convert.
        /// </param>
        private void ConvertByteArray(byte[] array)
        {
            // If this platform using the little endian byte order.
            if(BitConverter.IsLittleEndian)
            {
                // Reverse array.
                Array.Reverse(array);
            }
        }

        /// <summary>
        /// Throws exception based on the specified error result.
        /// </summary>
        /// <param name="result">
        /// A value representing which error occurred.
        /// </param>
        private void ThrowOnError(MidiFileResult result)
        {
            // If an error occurred.
            if(result != MidiFileResult.Success)
            {
                // Throw exception.
                throw new MidiFileException(result);
            }
        }

        /// <summary>
        /// Reads the next channel message.
        /// </summary>
        /// <param name="status">
        /// The status value for the next channel message.
        /// </param>
        /// <returns>
        /// The next channel message.
        /// </returns>
        private ChannelMessage ReadChannelMessage(int status)
        {
            ChannelMessage msg;
            ChannelCommand command = (ChannelCommand)(status & ChannelMask);
            int channel = status & ~ChannelMask;
            int data1 = binReader.ReadByte();

            // If this is a channel message that has two data bytes.
            if(command != ChannelCommand.ChannelPressure &&
                command != ChannelCommand.ProgramChange)
            {
                // Get second data byte.
                int data2 = binReader.ReadByte();

                // Create channel message.
                msg = new ChannelMessage(command, channel, data1, data2);
            }
            // Else this channel message only has one data byte.
            else
            {
                // Create channel message.
                msg = new ChannelMessage(command, channel, data1);
            }

            return msg;
        }

        /// <summary>
        /// Reads the next channel message.
        /// </summary>
        /// <param name="status">
        /// The status value for the next channel message.
        /// </param>
        /// <param name="data1">
        /// The first data byte.
        /// </param>
        /// <returns>
        /// The next channel message.
        /// </returns>
        private ChannelMessage ReadChannelMessage(int status, int data1)
        {
            ChannelMessage msg;
            ChannelCommand command = (ChannelCommand)(status & ChannelMask);
            int channel = status & ~ChannelMask;

            // If this is a channel message that has two data bytes.
            if(command != ChannelCommand.ChannelPressure &&
                command != ChannelCommand.ProgramChange)
            {
                // Get second data byte.
                int data2 = binReader.ReadByte();

                // Create channel message.
                msg = new ChannelMessage(command, channel, data1, data2);
            }
            // Else this channel message only has one data byte.
            else
            {
                // Create channel message.
                msg = new ChannelMessage(command, channel, data1);
            }

            return msg;
        }

        /// <summary>
        /// Reads variable length quantities from the Midi file.
        /// </summary>
        /// <returns>
        /// The variable length quantity packed into an integer.
        /// </returns>
        private int ReadVariableLengthQuantity()
        {
            bool done = false;
            int value = 0; 

            // While there are still bytes left to pack.
            while(!done)
            {
                // Read next byte.
                byte b = binReader.ReadByte();

                // If this is note the last byte.
                if((b & StatusFlag) == StatusFlag)
                {
                    // Mask eigth bit.
                    b &= 0x7F;
                }
                // Else this is the last byte.
                else
                {
                    // Indicate that this is the last byte to pack.
                    done = true;
                }

                // Shift value and pack next byte.
                value <<= Shift;
                value |= b;
            }

            return value;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the Midi file's format type.
        /// </summary>
        public short Format
        {
            get
            {
                return format;
            }
        }

        /// <summary>
        /// Gets the sequence created from the Midi file.
        /// </summary>
        public Sequence Sequence
        {
            get
            {
                return sequence;
            }
        }

        #endregion

        #endregion
	}
}
