using System;
using System.Collections;
using CustomTools;


namespace Architecture
{

    public abstract class Game
    {

        #region EVENTS

        public static event Action OnGameInitializedEvent;

        #endregion


        public static ArchitectureComponentState state { get; private set; } = ArchitectureComponentState.NotInitialized;
        public static bool isInitialized => state == ArchitectureComponentState.Initialized;
        public static ISceneManager sceneManager { get; private set; }
        public static IGameSettings gameSettings { get; private set; }



        #region GAME RUNNING

        public static void Run()
        {
            Coroutines.Start(RunGameRoutine());
        }

        private static IEnumerator RunGameRoutine()
        {
            state = ArchitectureComponentState.Initializing;

            InitSceneManager();
            yield return null;

            yield return sceneManager.InitializeCurrentScene();

            state = ArchitectureComponentState.Initialized;
            OnGameInitializedEvent?.Invoke();
        }

        private static void InitSceneManager()
        {
            sceneManager = new SceneManager(); ;
        }

        #endregion


        public static T GetInteractor<T>() where T : IInteractor
        {
            return sceneManager.sceneActual.GetInteractor<T>();
        }


        public static T GetRepository<T>() where T : IRepository
        {
            return sceneManager.sceneActual.GetRepository<T>();
        }

    }
}

