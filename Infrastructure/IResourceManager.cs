namespace Infrastructure
{
    using System.Collections.Generic;
    using System.Windows;

    /// <summary>
    /// Provides a facility to add/remove resource dictionaries from the application "core" resources
    /// </summary>
    public interface IResourceManager
    {
        /// <summary>
        /// Switches a set of dictionaryies in the application resource dictionary.
        /// </summary>
        /// <param name="oldDictionaries">Old dictionaries to remove, can be null if none to remove.</param>
        /// <param name="newDictionaries">New dictionaries to add, can be null if none to add.</param>
        void SwitchDictionaries(IEnumerable<ResourceDictionary> oldDictionaries, IEnumerable<ResourceDictionary> newDictionaries);
    }
}