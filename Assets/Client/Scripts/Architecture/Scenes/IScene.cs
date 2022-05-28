using System.Collections.Generic;
using UnityEngine;


namespace Architecture
{
    public interface IScene
    {

        SceneConfig sceneConfig { get; }
        ComponentsBase<IRepository> repositoriesBase { get; }
        ComponentsBase<IInteractor> interactorsBase { get; }

        void BuildUI();
        void SendMessageOnCreate();
        Coroutine InitializeAsync();
        void Start();

        T GetRepository<T>() where T : IRepository;

        T GetInteractor<T>() where T : IInteractor;

    }
}
