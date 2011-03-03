namespace Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;

    using Infrastructure.Messages;

    /// <summary>
    /// Provides a base class for module specific skin managers for making a module skinnable.
    /// </summary>
    public abstract class SkinManagerBase
    {
        /// <summary>
        /// List of dictionaries that have been added with the ResourceManager
        /// </summary>
        private List<ResourceDictionary> dictionaries;

        /// <summary>
        /// Gets a collection of uri strings representing the "skinnable" dictionaries.
        /// </summary>
        protected abstract IEnumerable<string> BaseDictionaryUriStrings { get; }

        /// <summary>
        /// Gets the current resource manager;
        /// </summary>
        protected abstract IResourceManager ResourceManager { get; }

        /// <summary>
        /// Gets a delegate that expands the dictionary name (if necessary) to include the given skin.
        /// </summary>
        protected abstract Func<string, string, string> DictionaryNameExpander { get; }

        /// <summary>
        /// Initialise the skin manager - BaseDictionaryUriStrings, ResourceManager and DictionaryNameExpander
        /// must be initialised before calling.
        /// </summary>
        /// <param name="skin">
        /// The initial skin to use.
        /// </param>
        public void Initialise(Skin skin)
        {
            this.dictionaries = new List<ResourceDictionary>(this.BaseDictionaryUriStrings.Count());
            this.dictionaries.AddRange(this.LoadDictionaries(skin.ToString()));
            this.ResourceManager.SwitchDictionaries(null, this.dictionaries);
        }

        /// <summary>
        /// Creates a "pack syntax" Uri string from a relative path to a resource
        /// </summary>
        /// <param name="relativeItemPath">
        /// The relative item path - e.g. /Styles/Dictionary.xaml
        /// </param>
        /// <returns>
        /// A string representing the pack syntax for accessing the given item.
        /// </returns>
        protected string CreatePackSyntaxUriString(string relativeItemPath)
        {
            var hostingAssembly = this.GetType().Assembly;

            var resourcePath = relativeItemPath.StartsWith("/") ? relativeItemPath.Remove(0, 1) : relativeItemPath;

            var uriString = string.Format("/{0};component/{1}", hostingAssembly.FullName, resourcePath);

            return uriString;
        }

        /// <summary>
        /// Switch the resource dictionaries to ones for the current skin
        /// </summary>
        /// <param name="newSkin">Skin to switch to</param>
        protected void SwitchSkin(string newSkin)
        {
            var newDictionaries = this.LoadDictionaries(newSkin);
            this.ResourceManager.SwitchDictionaries(this.dictionaries, newDictionaries);
            this.dictionaries.Clear();
            this.dictionaries.AddRange(newDictionaries);
        }

        /// <summary>
        /// Load a resource dictionary from the specified Uri.
        /// </summary>
        /// <param name="uri">
        /// The uri to load from.
        /// </param>
        /// <returns>
        /// A resource dictionary, or null if not loaded.
        /// </returns>
        private static ResourceDictionary LoadDictionary(string uri)
        {
            try
            {
                return Application.LoadComponent(new Uri(uri, UriKind.Relative)) as ResourceDictionary;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Load ResourceDictionaries for the given skin.
        /// </summary>
        /// <param name="skin">
        /// The skin to load.
        /// </param>
        /// <returns>
        /// An collection of ResourceDictionary for the current skin.
        /// </returns>
        private IEnumerable<ResourceDictionary> LoadDictionaries(string skin)
        {
            var loadedDictionaries = new List<ResourceDictionary>(this.BaseDictionaryUriStrings.Count());
            
            loadedDictionaries.AddRange(this.BaseDictionaryUriStrings.Select(s => this.DictionaryNameExpander(s, skin)).Select(LoadDictionary));

            return loadedDictionaries;
        }
    }
}
