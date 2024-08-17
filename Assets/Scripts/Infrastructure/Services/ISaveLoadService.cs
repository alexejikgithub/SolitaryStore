using System.Collections.Generic;

public interface ISaveLoadService : IService
{

    public List<ISaveProgress> SaveProgressesListeners { get; }
    public List<ILoadProgress> LoadProgressesListeners{ get; }
    StoreProgress LoadProgress();
    void SaveProgress();

    void RegisterSaveListener(ISaveProgress listener);
    void RegisterLoadListener(ILoadProgress listener);
    
    void UnRegisterSaveListener(ISaveProgress listener);
    void UnRegisterLoadListener(ILoadProgress listener);
}

