using System;

using ArticulationUtility.Domain.MidiEvents.Value;

namespace ArticulationUtility.Domain.MidiEvents
{
    /// <summary>
    /// Representing a MIDI note on.
    /// </summary>
    public class MidiNoteOn : IMidiEvent
    {
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public MidiNoteOn( MidiNoteNumber noteNumber, MidiVelocity velocity )
        {
            DataByte1 = noteNumber ?? throw new ArgumentNullException( $"{nameof( noteNumber )}" );
            DataByte2 = velocity ?? throw new ArgumentNullException( $"{nameof( velocity )}" );
        }

    }
}