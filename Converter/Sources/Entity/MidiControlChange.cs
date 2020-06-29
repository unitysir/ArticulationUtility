using System;

using Spreadsheet2Expressionmap.Converter.Entity.Value;

namespace Spreadsheet2Expressionmap.Converter.Entity
{
    /// <summary>
    /// Represents a MIDI control change.
    /// </summary>
    public class MidiControlChange : IMidiEvent<MidiControlNumber, MidiControlValue>
    {
        public MidiControlNumber DataByte1 { get; }
        public MidiControlValue DataByte2 { get; }

        public MidiControlChange( MidiControlNumber controlNumber, MidiControlValue controlValue )
        {
            DataByte1 = controlNumber ?? throw new ArgumentNullException( $"{nameof( controlNumber )}" );
            DataByte2 = controlValue ?? throw new ArgumentNullException( $"{nameof( controlValue )}" );
        }
    }
}