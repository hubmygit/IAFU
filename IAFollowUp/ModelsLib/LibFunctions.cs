using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IAFollowUp
{
    class LibFunctions
    {
        public static T getComboboxItem<T>(ComboBox cb)
        {
            T ret = ((T)((ComboboxItem)cb.SelectedItem).Value);

            return ret;
        }



    }
}
