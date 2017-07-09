using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using osu_tourney_tool.UI.Pages;

namespace osu_tourney_tool.UI.Windows
{
    public abstract class NavigationWindow : Window
    {
        protected Frame Frame;

        protected NavigationWindow()
        {
           
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            Frame = (Frame)this.FindName("WindowContent");
            
        }

        public void OpenPage(BasePage page)
        {
            Debug.Assert(Frame != null, "This windows does not contain a frame with name: WindowContent or its not initalized. ");
            Frame.Content = page;
        }
    }
}
