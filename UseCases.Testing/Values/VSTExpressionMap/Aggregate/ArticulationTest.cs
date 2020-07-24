using ArticulationUtility.UseCases.Values.VSTExpressionMap.Aggregate;
using ArticulationUtility.UseCases.Values.VSTExpressionMap.Value;

using NUnit.Framework;

namespace UseCases.Testing.Values.VSTExpressionMap.Aggregate
{
    [TestFixture]
    public class ArticulationTest
    {
        [Test]
        public void SetupArticulationTest()
        {
            var articulation = new Articulation( ArticulationId.Increment(),  new ArticulationName( "Name" ), ArticulationType.Direction, new ArticulationGroup( 1 ) );
        }
    }
}