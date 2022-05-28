namespace Architecture
{
	public interface IArchitectureCaptureEvents
	{

		/// Called when all repositories and interactors created;
		void OnCreate();
		/// Called when all repositories and interactors initialized;
		void OnInitialize();
		/// Called when all repositories and interactors started;
		void OnStart();
	}
}
