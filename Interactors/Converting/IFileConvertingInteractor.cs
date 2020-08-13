using ArticulationUtility.Gateways;
using ArticulationUtility.UseCases.Converting;

namespace ArticulationUtility.Interactors.Converting
{
    public interface IFileConvertingInteractor<TSource, TTarget> : IConvertingUseCase<ConvertingFileFormatRequest>
    {
        public IFileRepository<TSource> SourceRepository { get; }
        public IFileRepository<TTarget> TargetRepository { get; }
    }
}