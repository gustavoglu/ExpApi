using Exp.Domain.Enums;
using System;
using Windows.UI.Xaml.Data;

namespace Exp.UWP.Converters
{
    public class StringToTipoDocumento : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            var tipoDocumento = (ETipoDocumento)value;
            return tipoDocumento.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;
            var valor = (string)value;
            var tipoDocumento = Enum.Parse<ETipoDocumento>(valor);
            return tipoDocumento;
        }
    }
}
