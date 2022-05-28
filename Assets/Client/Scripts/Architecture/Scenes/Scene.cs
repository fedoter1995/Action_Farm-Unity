using System;
using System.Collections;
using UnityEngine;

namespace Architecture
{
    public sealed class Scene : IScene
    {
        public SceneConfig sceneConfig { get; }
        public ComponentsBase<IRepository> repositoriesBase { get; }
        public ComponentsBase<IInteractor> interactorsBase { get; }



        public Scene(SceneConfig config)
        {
            sceneConfig = config;
            repositoriesBase = new ComponentsBase<IRepository>(sceneConfig.repositoriesReferences);
            interactorsBase = new ComponentsBase<IInteractor>(sceneConfig.interactorsReferences);
        }

        public void BuildUI()
        {
            //UI.Build(sceneConfig);
        }



        #region ONCREATE

        public void SendMessageOnCreate()
        {
            repositoriesBase.SendMessageOnCreate();
            repositoriesBase.SendMessageOnCreate();
            //UI.controller.SendMessageOnCreate();
        }

        #endregion


        #region INITIALIZE

        public Coroutine InitializeAsync()
        {
            return CustomTools.Coroutines.Start(InitializeAsyncRoutine());
        }

        private IEnumerator InitializeAsyncRoutine()
        {
            yield return repositoriesBase.InitializeAllComponents();
            yield return interactorsBase.InitializeAllComponents();

            repositoriesBase.SendMessageOnInitialize();
            interactorsBase.SendMessageOnInitialize();
            //UI.controller.SendMessageOnInitialize();
        }

        #endregion


        #region START

        public void Start()
        {
            repositoriesBase.SendMessageOnStart();
            interactorsBase.SendMessageOnStart();
            //UI.controller.SendMessageOnStart();
        }


        #endregion


        public T GetRepository<T>() where T : IRepository
        {
            return repositoriesBase.GetComponent<T>();
        }


        public T GetInteractor<T>() where T : IInteractor
        {
            return interactorsBase.GetComponent<T>();
        }

    }
}

