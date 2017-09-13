using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fabrikam
{
    class ExtendedViewCell : ViewCell
    {
        private Color light = new Color(242, 229, 207);
        private Color medium = new Color(219, 202, 127);
        private Color dark = new Color(202, 151, 63);
        private Color selectedCol = new Color(209, 168, 92);
        private Color favouriteCol = new Color(206, 193, 81);

        bool Favourite { get; set; }

        public ExtendedViewCell()
        {
            this.Tapped += (sender, args) =>
            {
                this.View.BackgroundColor = selectedCol;
                // tapped handler
                if (Favourite)
                {
                    this.View.BackgroundColor = favouriteCol;
                } else
                {
                    this.View.BackgroundColor = medium;
                }
            };
        }
    }
}
