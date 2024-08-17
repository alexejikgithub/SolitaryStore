using System.Collections.Generic;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private const string ProgressKey = "Progress";
    private readonly IProgressService _progressService;

    private List<ISaveProgress> _saveProgressesListeners = new List<ISaveProgress>();
    private List<ILoadProgress> _loadProgressesListeners = new List<ILoadProgress>();

    public List<ISaveProgress> SaveProgressesListeners => _saveProgressesListeners;
    public List<ILoadProgress> LoadProgressesListeners => _loadProgressesListeners;


    public SaveLoadService(IProgressService progressService)
    {
        _progressService = progressService;
    }

    public StoreProgress LoadProgress()
    {
        return PlayerPrefs.GetString(ProgressKey)?.ToDeserialized<StoreProgress>();
    }

    public void SaveProgress()
    {
        foreach (ISaveProgress progressWriter in _saveProgressesListeners)
        {
            progressWriter.SaveProgress(_progressService.StoreProgress);
        }

        PlayerPrefs.SetString(ProgressKey, _progressService.StoreProgress.ToJson());
    }

    public void RegisterSaveListener(ISaveProgress listener)
    {
        _saveProgressesListeners.Add(listener);
    }

    public void RegisterLoadListener(ILoadProgress listener)
    {
        _loadProgressesListeners.Add(listener);
    }

    public void UnRegisterSaveListener(ISaveProgress listener)
    {
        _saveProgressesListeners.Remove(listener);
    }

    public void UnRegisterLoadListener(ILoadProgress listener)
    {
        _loadProgressesListeners.Remove(listener);
    }
}