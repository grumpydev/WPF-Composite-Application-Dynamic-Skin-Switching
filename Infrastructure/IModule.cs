namespace Infrastructure
{
    /// <summary>
    /// Represents an application module
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Initialise the module
        /// </summary>
        void Initialise();
    }
}