using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace osu_tourney_tool.UI.Pages
{
    public abstract class BasePage : Page
    {
        protected NavigationWindow Window;


        public void Attach(NavigationWindow window)
        {
            this.Window = window;
            OnAttach();
        }

        protected virtual void OnAttach() { }
    }
}