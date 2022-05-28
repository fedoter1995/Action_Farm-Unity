using System;
using UnityEngine;

namespace Architecture
{
	public interface IArchitectureComponent : IArchitectureCaptureEvents
	{
		event Action OnInitializedEvent;

		ArchitectureComponentState state { get; }
		bool isInitialized { get; }
		bool isLoggingEnabled { get; set; }

		Coroutine InitializeWithRoutine();
	}
}