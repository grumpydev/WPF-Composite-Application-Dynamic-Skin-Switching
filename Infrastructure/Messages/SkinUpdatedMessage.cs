namespace Infrastructure.Messages
{
    public class SkinUpdatedMessage : TinyMessenger.TinyMessageBase
    {
        public SkinUpdatedMessage(object sender, Skin skin)
            : base(sender)
        {
            this.Skin = skin;
        }

        /// <summary>
        /// Gets Skin.
        /// </summary>
        public Skin Skin { get; private set; }
    }
}
