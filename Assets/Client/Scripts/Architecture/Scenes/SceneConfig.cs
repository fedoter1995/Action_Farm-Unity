using Utils.Attributes;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Architecture
{
    [CreateAssetMenu(fileName = "SceneConfig", menuName = "Architecture/Scenes/New SceneConfig")]
    public sealed class SceneConfig : ScriptableObject
    {

        [SerializeField, SceneName] private string _sceneName;

        [Header("======= CORE ARCHITECTURE =======")]
        [SerializeField, ClassReference(typeof(Repository))]
        private string[] _repositoryReferences;

        [SerializeField, ClassReference(typeof(Interactor))]
        private string[] _interactorsReferences;




        public string sceneName => _sceneName;
        public string[] repositoriesReferences => _repositoryReferences;
        public string[] interactorsReferences => _interactorsReferences;
    }
}

