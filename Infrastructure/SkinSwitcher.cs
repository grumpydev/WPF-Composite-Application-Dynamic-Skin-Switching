namespace Infrastructure
{
    using Infrastructure.Messages;

    using TinyMessenger;

    /// <summary>
    /// Enables switching of UI skins
    /// </summary>
    public class SkinSwitcher : ISkinSwitcher
    {
        /// <summary>
        /// Message hub for sending update messages
        /// </summary>
        private readonly ITinyMessengerHub messageHub;

        /// <summary>
        /// Initializes a new instance of the <see cref="SkinSwitcher"/> class.
        /// </summary>
        /// <param name="messageHub">
        /// The message hub to use.
        /// </param>
        public SkinSwitcher(ITinyMessengerHub messageHub)
        {
            this.CurrentSkin = Skin.Normal;
            this.messageHub = messageHub;
        }

        /// <summary>
        /// Gets the current skin.
        /// </summary>
        public Skin CurrentSkin { get; private set; }

        /// <summary>
        /// Switched the UI to the current skin.
        /// </summary>
        /// <param name="newSkin">
        /// The new skin.
        /// </param>
        public void SwitchSkin(Skin newSkin)
        {
            this.CurrentSkin = newSkin;
            this.messageHub.Publish(new SkinUpdatedMessage(this, newSkin));
        }
    }
}