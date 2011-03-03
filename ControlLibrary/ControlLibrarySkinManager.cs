namespace ControlLibrary
{
    using System;
    using System.Collections.Generic;

    using Infrastructure;
    using Infrastructure.Messages;

    using TinyMessenger;

    public class ControlLibrarySkinManager : SkinManagerBase
    {
        private ITinyMessengerHub messageHub;

        private IResourceManager resourceManager;

        public ControlLibrarySkinManager(ITinyMessengerHub messageHub, IResourceManager resourceManager)
        {
            this.messageHub = messageHub;
            this.resourceManager = resourceManager;

            messageHub.Subscribe<SkinUpdatedMessage>(m => this.SwitchSkin(m.Skin.ToString()));
        }

        protected override IEnumerable<string> BaseDictionaryUriStrings
        {
            get
            {
                return new[]
                    {
                        CreatePackSyntaxUriString("/Resources/ControlResources--[SKIN].xaml"), 
                    };
            }
        }

        protected override IResourceManager ResourceManager
        {
            get
            {
                return this.resourceManager;
            }
        }

        protected override Func<string, string, string> DictionaryNameExpander
        {
            get
            {
                return (name, skin) => name.Replace("[SKIN]", skin);
            }
        }
    }
}