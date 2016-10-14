
namespace Sage.CA.SBS.ERP.Sage300.Common.Models.Portal
{
    public class WidgetOrder
    {
        /// <summary>
        /// Gets or sets the WidgetId
        /// </summary>
        public string WidgetId { get; set; }

        /// <summary>
        /// Gets or sets the WidgetName
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// Gets or sets the Rank
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Gets or sets the widget url
        /// </summary>
        public string ScreenUrl { get; set; }

        /// <summary>
        /// Gets or sets if the widget is configurable
        /// </summary>
        public bool? IsConfigurable { get; set; }

        /// <summary>
        /// Gets or sets if the widget has report
        /// </summary>
        public bool? IsReport { get; set; }

    }
}
