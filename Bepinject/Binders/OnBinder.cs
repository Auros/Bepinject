namespace Bepinject
{
    public class OnBinder : RootBinder
    {
        public RootBinder OnContract(string contractName)
        {
            OnContracts(new string[1] { contractName });
            return this;
        }

        public RootBinder OnContracts(params string[] contractNames)
        {
            base.contractNames = contractNames;
            return this;
        }
        
        public RootBinder OnScene(string sceneName)
        {
            OnScenes(new string[1] { sceneName });
            return this;
        }

        public RootBinder OnScenes(params string[] sceneNames)
        {
            base.sceneNames = sceneNames;
            return this;
        }

        public RootBinder OnProject()
        {
            onProject = true;
            return this;
        }
    }
}