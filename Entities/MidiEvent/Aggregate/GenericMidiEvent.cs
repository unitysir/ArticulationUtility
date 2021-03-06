using System;

using ArticulationUtility.Entities.MidiEvent.Value;

namespace ArticulationUtility.Entities.MidiEvent.Aggregate
{
    /// <summary>
    /// Generic MIDI Event.
    /// </summary>
    public class GenericMidiEvent : IMidiEvent
    {
        public IMidiEventData Status { get; }
        public IMidiEventData DataByte1 { get; }
        public IMidiEventData DataByte2 { get; }

        public GenericMidiEvent( IMidiEventData status, IMidiEventData data1, IMidiEventData data2 )
        {
            Status    = status ?? throw new ArgumentNullException( $"{nameof( status )}" );
            DataByte1 = data1 ?? throw new ArgumentNullException( $"{nameof( data1 )}" );
            DataByte2 = data2 ?? throw new ArgumentNullException( $"{nameof( data2 )}" );
        }

    }
}