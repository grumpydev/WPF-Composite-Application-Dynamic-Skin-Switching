namespace Infrastructure
{
    using Infrastructure.Messages;

    /// <summary>
    /// Enables switching of UI skins
    /// </summary>
    public interface ISkinSwitcher
    {
        /// <summary>
        /// Gets the current skin.
        /// </summary>
        Skin CurrentSkin { get; }

        /// <summary>
        /// Switched the UI to the current skin.
        /// </summary>
        /// <param name="newSkin">
        /// The new skin.
        /// </param>
        void SwitchSkin(Skin newSkin);
    }
}