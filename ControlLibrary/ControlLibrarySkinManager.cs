namespace ControlLibrary
{
    using System;
    using System.Collections.Generic;

    using Infrastructure;

    using TinyMessenger;

    public class ControlLibrarySkinManager : SkinManagerBase
    {
        public ControlLibrarySkinManager(ITinyMessengerHub messageHub, IResourceManager resourceManager)
            : base(messageHub, resourceManager)
        {
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

        protected override Func<string, string, string> DictionaryNameExpander
        {
            get
            {
                return (name, skin) => name.Replace("[SKIN]", skin);
            }
        }
    }
}