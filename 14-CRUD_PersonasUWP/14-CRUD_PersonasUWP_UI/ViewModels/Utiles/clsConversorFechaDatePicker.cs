using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _14_CRUD_PersonasUWP_UI.ViewModels.Utils
{
    public class clsConversorFechaDatePicker : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DateTime fecha = (DateTime)value;

            //Para evitar que pete por tener el año como 1
            if (fecha.Year < 1919)
            {
                fecha = new DateTime(1919, fecha.Month, fecha.Day);
            }

            DateTimeOffset fechaDevuelta = new DateTimeOffset(fecha);

            return fechaDevuelta;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            DateTimeOffset fechaOffSet = (DateTimeOffset)value;
            DateTime fecha = fechaOffSet.DateTime;

            return fecha;
        }
    }
}
