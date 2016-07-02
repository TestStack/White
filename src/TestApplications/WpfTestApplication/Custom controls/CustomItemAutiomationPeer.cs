// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomItemAutiomationPeer.cs" company="TestStack">
//   All rights reserved.
// </copyright>
// <summary>
//   Defines the CustomItemAutiomationPeer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace WpfTestApplication.Custom_controls
{
    using System.Windows.Automation.Peers;

    /// <summary>
    ///     The custom item automation peer.
    /// </summary>
    public class CustomItemAutiomationPeer : UIElementAutomationPeer
    {
        /// <summary>
        ///     The custom item.
        /// </summary>
        private readonly CustomItem customItem;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomItemAutiomationPeer" /> class.
        /// </summary>
        /// <param name="customItem">
        ///     The custom item.
        /// </param>
        public CustomItemAutiomationPeer(CustomItem customItem)
            : base(customItem)
        {
            this.customItem = customItem;
        }

        /// <summary>
        ///     The get automation id core.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        protected override string GetAutomationIdCore()
        {
            return this.customItem.GetType().Name;
        }

        /// <summary>
        ///     The get class name core.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        protected override string GetClassNameCore()
        {
            return this.customItem.GetType().Name;
        }

        /// <summary>
        ///     The get name core.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        protected override string GetNameCore()
        {
            return this.customItem.Name;
        }
    }
}