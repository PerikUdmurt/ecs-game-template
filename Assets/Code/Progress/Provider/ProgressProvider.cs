using Code.Progress.Data;
using JetBrains.Annotations;

namespace Code.Progress.Provider
{
  [UsedImplicitly]
  public class ProgressProvider : IProgressProvider
  {
    private readonly IInitialProgressProvider _initialProgressProvider;

    public ProgressProvider(IInitialProgressProvider initialProgressProvider)
    {
      _initialProgressProvider = initialProgressProvider;
      ProgressData = new ProgressData();
    }
    
    public ProgressData ProgressData { get; private set; }

    public void SetProgressData(ProgressData data) =>
      ProgressData = data;

    public void CreateNewProgressData() =>
      SetProgressData(_initialProgressProvider.GetInitialProgressData());
  }
}