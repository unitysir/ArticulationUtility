namespace ArticulationUtility.UseCases.VSTExpressionMapXml.Classes
{
    public static class InstrumentMap
    {
        public static InstrumentMapElement New( string mapName)
        {
            var obj = new InstrumentMapElement( mapName );

            var controller = new MemberElement( "controller" );
            controller.Int.Add( new IntElement( "ownership", 1 ) );

            obj.Member.Add( controller );

            return obj;
        }

        public static MemberElement Slotvisuals( string name, ListElement listOfUSlotVisuals )
        {
#if false
   <member name="slotvisuals">
      <int name="ownership" value="1"/>
      <list name="obj" type="obj">
         <obj class="USlotVisuals" ID="3316603083">
            <int name="displaytype" value="1"/>
            <int name="articulationtype" value="1"/>
            <int name="symbol" value="73"/>
            <string name="text" value="IDLE" wide="true"/>
            <string name="description" value="IDLE" wide="true"/>
            <int name="group" value="0"/>
         </obj>
                  <obj class="USlotVisuals" ID="1335843239">
            <int name="displaytype" value="1"/>
            <int name="articulationtype" value="1"/>
            <int name="symbol" value="73"/>
            <string name="text" value="Power Chord" wide="true"/>
            <string name="description" value="Power Chord" wide="true"/>
            <int name="group" value="0"/>
         </obj>
      </list>
   </member>
#endif
            var member = new MemberElement( "slotvisuals" );
            member.Int.Add( new IntElement( "ownership", 1 ) );

            if( listOfUSlotVisuals != null )
            {
                listOfUSlotVisuals.Name = "obj";
                listOfUSlotVisuals.Type = "obj";
                member.List.Add( listOfUSlotVisuals );
            }

            return member;

        }

        public static MemberElement Slots( ListElement listOfPSoundSlot = null )
        {
            var member = new MemberElement( "slotvisuals" );

            member.Int.Add( new IntElement( "ownership", 1 ) );

            if( listOfPSoundSlot != null )
            {
                listOfPSoundSlot.Name = "obj";
                listOfPSoundSlot.Type = "obj";
                member.List.Add( listOfPSoundSlot );
            }

            return member;
        }
    }
}