using Laixer.Kadaster.Bag;

namespace Laixer.Kadaster
{
    /// <summary>
    /// Kadaster registration.
    /// </summary>
    /// <typeparam name="TServiceSelector"></typeparam>
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
