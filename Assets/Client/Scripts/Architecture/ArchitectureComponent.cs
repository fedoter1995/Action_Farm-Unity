using System;
using System.Collections;
using UnityEngine;
using CustomTools;


namespace Architecture
{
	public abstract class ArchitectureComponent : IArchitectureComponent
	{

		#region EVENTS

		public event Action OnInitializedEvent;

		#endregion


		public ArchitectureComponentState state { get; private set; }
		public bool isInitialized => this.state == ArchitectureComponentState.Initialized;
		public bool isLoggingEnabled { get; set; }


		public ArchitectureComponent()
		{
			this.state = ArchitectureComponentState.NotInitialized;
		}

		public virtual void OnCreate() { }



		#region INITIALIZATION

		public Coroutine InitializeWithRoutine()
		{
			if (isInitialized)
				throw new Exception($"Component {this.GetType().Name} is already initialized");

			if (state == ArchitectureComponentState.Initializing)
				throw new Exception($"Component {this.GetType().Name} is initializing now");

			return Coroutines.Start(InitializeRoutineInternal());
		}


		private IEnumerator InitializeRoutineInternal()
		{
			state = ArchitectureComponentState.Initializing;
			yield return Coroutines.Start(InitializeRoutine());
			Initialize();

			state = ArchitectureComponentState.Initialized;
			OnInitializedEvent?.Invoke();
		}

		/// <summary>
		/// Initialization contains two parts: with routine and without routine. This method (without routine) runs
		/// AFTER initialization with routine.
		/// </summary>
		protected virtual void Initialize() { }

		/// <summary>
		/// Initialization contains two parts: with routine and without routine. This method (with routine) runs
		/// BEFORE initialization without routine.
		/// </summary>
		protected virtual IEnumerator InitializeRoutine()
		{
			yield break;
		}

		public virtual void OnInitialize() { }

		#endregion


		public virtual void OnStart() { }

		protected void Log(string text)
		{
			if (this.isLoggingEnabled)
				Debug.Log(text);
		}
	}

	public enum ArchitectureComponentState
	{
		NotInitialized,
		Initializing,
		Initialized
	}
}
