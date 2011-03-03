namespace ControlLibrary
{
    using Infrastructure;

    using TinyMessenger;

    public class Module : IModule
    {
        private ITinyMessengerHub messageHub;

        private ISkinSwitcher skinSwitcher;

        private SkinManagerBase skinManager;

        public Module(ITinyMessengerHub messageHub, ISkinSwitcher skinSwitcher, IResourceManager resourceManager)
        {
            this.messageHub = messageHub;
            this.skinSwitcher = skinSwitcher;
            this.skinManager = new ControlLibrarySkinManager(messageHub, resourceManager);
        }

        public void Initialise()
        {
            var currentSkin = skinSwitcher.CurrentSkin;
            this.skinManager.Initialise(currentSkin);
        }
    }
}
