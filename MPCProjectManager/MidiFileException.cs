/*
 * Created by: Leslie Sanford
 * 
 * Contact: jabberdabber@hotmail.com
 * 
 * Last modified: 04/08/2004
 */

using System;
using System.Reflection;
using System.Resources;

namespace Multimedia.Midi
{
    /// <summary>
    /// Error codes for Midi file operations.
    /// </summary>
    internal enum MidiFileResult 
    { 
        /// <summary>
        /// The Midi file operation was successful.
        /// </summary>
        Success, 

        /// <summary>
        /// The specified file is not a Midi file.
        /// </summary>
        NotMidiFile, 

        /// <summary>
        /// The Midi file format value is either out of range or the number of 
        /// tracks does not match the format type.
        /// </summary>
        InvalidFormat,

        /// <summary>
        /// The end of the Midi file was unexpectedly reached.
        /// </summary>
        EndofFileError
    };

	/// <summary>
    /// The exception that is thrown when a Midi file operation fails.
	/// </summary>
	public class MidiFileException : ApplicationException
	{  
        // Table of error messages.
        private static readonly string[] ErrorMessages;
        
        // Error code result.
        private MidiFileResult result;

        // Resource manager - gets error messages for exceptions.
        private static ResourceManager resManager = 
            new ResourceManager("Multimedia.Midi.MidiFileResource",
            Assembly.GetExecutingAssembly());

        /// <summary>
        /// Initializes class data.
        /// </summary>
        static MidiFileException()
        {
            // Create table for error messages.
            ErrorMessages = new string[4];

            //
            // Load error messages.
            //

            ErrorMessages[0] = resManager.GetString("Success");
            ErrorMessages[1] = resManager.GetString("NotMidiFile");
            ErrorMessages[2] = resManager.GetString("InvalidFormat");
            ErrorMessages[3] = resManager.GetString("EndOfFileError");
        }

        /// <summary>
        /// Initializes a new instance of the MidiFileException class with the
        /// specified error code.
        /// </summary>
        /// <param name="result">
        /// Error code.
        /// </param>
		internal MidiFileException(MidiFileResult result)
		{
            this.result = result;
		}

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return ErrorMessages[(int)result];
            }
        }
	}
}
