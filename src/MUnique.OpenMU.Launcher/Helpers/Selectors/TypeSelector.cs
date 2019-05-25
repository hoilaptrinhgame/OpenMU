using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace MUnique.OpenMU.Launcher.Helpers.Selectors
{
    public class TypeSelector : DataTemplateSelector
    {
        public DataTemplate BoolTemplate { get; set; }
        public DataTemplate StringTemplate { get; set; }
        public DataTemplate EmptyTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item,
            DependencyObject container)
        {
            if (!(item is PropertyInfo info))
            {
                return EmptyTemplate;
            }

            if (info.PropertyType == typeof(bool))
            {
                return BoolTemplate;
            }
            
            if (info.PropertyType == typeof(string))
            {
                return StringTemplate;
            }

            return EmptyTemplate;
        }
    }
}