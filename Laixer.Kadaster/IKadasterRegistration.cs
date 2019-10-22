namespace Laixer.Kadaster
{
    internal interface IKadasterRegistration<TServiceSelector>
    {
        /// <summary>
        /// Return a service available in this registration.
        /// </summary>
        /// <param name="designation"></param>
        /// <returns>Instance of <see cref="IBagService"/>.</returns>
        IBagService GetService(TServiceSelector selector);
    }
}
